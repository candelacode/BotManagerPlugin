# Seguridad

## Cifrado

Actualmente ASF soporta los siguientes métodos de cifrado como una definición de `ECryptoMethod`:

| Valor | Nombre                      |
| ----- | --------------------------- |
| 0     | PlainText                   |
| 1     | AES                         |
| 2     | ProtectedDataForCurrentUser |
| 3     | EnvironmentVariable         |
| 4     | File                        |

La descripción exacta y comparación de las mismas están disponibles a continuación.

### Configuración

Para generar una contraseña cifrada, por ejemplo, para uso de `SteamPassword`, debes ejecutar el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `encrypt` con el cifrado que elegiste y tu contraseña en texto plano. Posteriormente, introduce la cadena de caracteres cifrada obtenida en la propiedad de configuración del bot `SteamPassword`, y finalmente cambia `PasswordFormat` al que corresponda con el método de cifrado elegido. Algunos formatos no requieren el comando `encrypt`, por ejemplo, `EnvironmentVariable` o `File`, solo poner la ruta apropiada para estos.

---

### `PlainText`

Esta es la forma más sencilla e insegura de almacenar una contraseña, definida como `ECryptoMethod` de `0`. ASF espera que la cadena de caracteres sea texto plano - una contraseña en su forma directa. Es la más fácil de usar, y 100% compatible con todas las configuraciones, por lo tanto la forma predeterminada de almacenar datos confidenciales, totalmente insegura para el almacenamiento.

---

### `AES`

Considerado seguro para los estándares actuales, la forma **[AES](https://es.wikipedia.org/wiki/Advanced_Encryption_Standard)** de almacenar la contraseña es definida como `ECryptoMethod` de `1`. ASF espera que la cadena sea una secuencia de caracteres **[base64-encoded](https://es.wikipedia.org/wiki/Base64)** resultante en un array de bytes cifrado en AES después de la traducción, que luego debe ser descifrado usando el **[vector de inicialización](https://es.wikipedia.org/wiki/Vector_de_inicializaci%C3%B3n)** incluido y la clave de cifrado de ASF.

El método anterior garantiza la seguridad siempre que el atacante no conozca la clave de cifrado de ASF, la cual es usada tanto para el descifrado como para el cifrado de contraseñas. ASF te permite especificar la clave a través del **[argumento de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-es-ES)** `--cryptkey`, el cual deberías usar para máxima seguridad. Si decides omitirlo, ASF usará su propia clave que es **conocida** y está en el código de la aplicación, lo que significa que cualquiera puede revertir el cifrado de ASF y obtener la contraseña descifrada. Requiere algo de esfuerzo y no es tan fácil de hacer, pero es posible, por eso casi siempre debes usar el cifrado `AES` con tu propia `--cryptkey` mantenida en secreto. El método AES usado en ASF proporciona una seguridad que debería ser satisfactoria y tiene un balance entre la simplicidad de `PlainText` y la complejidad de `ProtectedDataForCurrentUser`, pero se recomienda mucho usarlo con una `--cryptkey` personalizada.

Si se utiliza correctamente (una `--cryptkey` personalizada y larga), garantiza una seguridad muy alta para el almacenamiento seguro.

---

### `ProtectedDataForCurrentUser`

Considerada segura para los estándares actuales,  la forma **<ahref="https://es.wikipedia.org/wiki/API_de_protección_de_datos">DPAPI</a>** para almacenar contraseñas está definida como `ECryptoMethod` de `2`. La ventaja principal de este método es al mismo tiempo la mayor desventaja - en lugar de usar una clave de cifrado (como en `AES`), la información es cifrada usando las credenciales de inicio de sesión del usuario que actualmente tiene la sesión iniciada, lo que significa que es posible descifrar la información **solo** en la máquina en la que fue cifrada, y además **solo** por el usuario que hizo el cifrado.

Esto asegura que incluso si envías todo tu archivo `Bot.json` con `SteamPassword` cifrada usando este método a alguien más, no será capaz de descifrar la contraseña sin acceso directo a tu PC. Esta es una excelente medida de seguridad, pero al mismo tiempo tiene la gran desventaja de ser menos compatible, ya que la contraseña cifrada usando este método no será compatible con ningún otro usuario ni otra máquina - incluyendo **la tuya propia** si decides, por ejemplo, reinstalar tu sistema operativo. Este es el método recomendado si no tienes que acceder a tus configuraciones desde otra máquina más que la tuya, y que tampoco necesitas compatibilidad entre máquinas.

**Ten en cuenta que actualmente esta opción solo está disponible para máquinas que ejecuten el sistema operativo Windows.**

---

### `EnvironmentVariable`

Almacenamiento basado en la memoria definido como `ECryptoMethod` de `3`. ASF leerá la contraseña de la variable de entorno con el nombre especificado en el campo de contraseña (por ejemplo, `SteamPassword`). Por ejemplo, establecer `SteamPassword` a `ASF_PASSWORD_MYACCOUNT` y `PasswordFormat` a `3` causará que ASF evalúe la variable de entorno `${ASF_PASSWORD_MYACCOUNT}` y usará como contraseña de la cuenta lo que esté asignado a dicha variable.

Recuerda asegurarte de que las variables de entorno del proceso ASF no sean accesibles por usuarios no autorizados, ya que esto frustra todo el propósito de utilizar este método.

---

### `File`

Almacenamiento basado en archivos (posiblemente fuera del directorio de configuración de ASF) definido como `ECryptoMethod` de `4`. ASF leerá la contraseña de la ruta del archivo especificada en el campo de contraseña (por ejemplo, `SteamPassword`). La ruta especificada puede ser absoluta, o relativa a la ubicación "inicio" de ASF (la carpeta que contenga el directorio `config`, tomando en cuenta el **[argumento de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-es-ES#argumentos)** `--path`). Este método se puede usar por ejemplo con los **[secretos de Docker](https://docs.docker.com/engine/swarm/secrets)**, que generan dichos archivos para su uso, pero también puede usarse fuera de Docker si creas el archivo apropiado. Por ejemplo, establecer `SteamPassword` a `/etc/secrets/MyAccount.pass` y `PasswordFormat` a `4` causará que ASF lea `/etc/secrets/MyAccount.pass` y use como contraseña de la cuenta lo que esté escrito en ese archivo.

Recuerda asegurarte de que el archivo que contenga la contraseña no sea legible por usuarios no autorizados, ya que eso arruina todo el propósito de usar este método.

---

## Recomendaciones de encriptación

Si la compatibilidad no es un problema para ti, y estás bien con cómo funciona el método `ProtectedDataForCurrentUser`, es la opción **recomendada** para almacenar la contraseña en ASF, ya que proporciona la mejor seguridad y conveniencia. El método `AES` es una buena opción para las personas que quieren usar sus configuraciones en cualquier máquina que deseen, mientras que `PlainText` es la forma más simple de almacenar la contraseña, si no te importa que cualquiera pueda buscarla en el archivo de configuración JSON.

Ten en cuenta que los 3 métodos de encriptación se consideran **inseguros** si el atacante tiene acceso a tu PC. ASF debe poder descifrar las contraseñas cifradas, y si el programa que se ejecuta en tu máquina puede hacer eso, entonces cualquier programa que se ejecute en la misma máquina será capaz de hacerlo también. `ProtectedDataForCurrentUser` es la variante más segura ya que **incluso otro usuario usando la misma PC no podrá descifrarla**, pero aún es posible descifrar la información si alguien es capaz de robar tus credenciales de acceso e información de tu máquina además del archivo de configuración de ASF.

Para configuraciones avanzadas, puedes usar `EnvironmentVariable` y `File`. Tienen un uso limitado, el `EnvironmentVariable` será buena idea si prefieres obtener la contraseña a través de algún tipo de solución personalizada y almacenarla exclusivamente en memoria, mientras que `File` es bueno, por ejemplo, con **[secretos de Docker](https://docs.docker.com/engine/swarm/secrets)**. Sin embargo, ambas son no cifradas, así que básicamente mueves el riesgo del archivo de configuración de ASF o lo que sea que elijas de esas dos.

Además de los métodos de cifrado especificados anteriormente, también es posible evitar completamente el uso de contraseñas, por ejemplo, usando una cadena de caracteres vacía o el valor `null` en la propiedad `SteamPassword`. ASF pedirá tu contraseña cuando sea necesario, y no la guardará en ningún lugar, solo la mantendrá en la memoria del proceso actual, hasta que lo cierres. Aunque es el método más seguro de tratar con contraseñas (no se guardan en ningún lugar), también es el más problemático, ya que necesitas introducir tu contraseña manualmente en cada ejecución de ASF (cuando sea requerido). Si eso no es un problema para ti, esta es tu mejor opción en términos de seguridad, no puedes filtrar algo que no existe.

---

## Descifrado

ASF no soporta ninguna forma de descifrar contraseñas ya cifradas, ya que los métodos de descifrado solo son usados internamente para acceder a la información dentro del proceso. Si deseas revertir el procedimiento de cifrado, por ejemplo, para mover ASF a otra máquina al usar `ProtectedDataForCurrentUser`, entonces simplemente repite el procedimiento desde el principio en el nuevo entorno.

---

## Hashing

Actualmente ASF soporta los siguientes métodos de hashing como una definición de `EHashingMethod`:

| Valor | Nombre    |
| ----- | --------- |
| 0     | PlainText |
| 1     | SCrypt    |
| 2     | Pbkdf2    |

La descripción exacta y comparación de las mismas están disponibles a continuación.

### Configuración

Para generar un hash, por ejemplo, para usar `IPCPassword`, debes ejecutar el **[comando](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)** `hash` con el método de hash apropiado que hayas elegido y tu contraseña original en texto plano. Posteriormente, introduce la cadena de caracteres con hash obtenida en la propiedad de configuración de ASF `IPCPassword`, y finalmente cambia `IPCPasswordFormat` al que corresponda con el método de hash elegido.

---

### `PlainText`

Esta es la forma más sencilla e insegura de aplicarle hash a una contraseña, definida como `EHashingMethod` de `0`. ASF generará un hash que coincida con la entrada original. Es la más fácil de usar, y 100% compatible con todas las configuraciones, por lo tanto la forma predeterminada de almacenar datos confidenciales, totalmente insegura para el almacenamiento.

---

### `SCrypt`

Considerada segura para los estándares actuales,  la forma **[SCrypt](https://en.wikipedia.org/wiki/Scrypt)** para aplicar hash a la contraseña está definida como `EHashingMethod` de `1`. ASF usará la implementación de `SCrypt` utilizando `8` bloques, `8192` iteraciones, longitud de hash de `32` y la clave de cifrado como sal para generar el array de bytes. Los bytes resultantes serán codificados como una cadena de caracteres **[base64](https://es.wikipedia.org/wiki/Base64)**.

ASF te permite especificar la sal para este método a través del **[argumento de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-es-ES)** `--cryptkey`, el cual deberías usar para máxima seguridad. Si decides omitirlo, ASF usará su propia clave que es **conocida** y está en el código de la aplicación, lo que significa que el hash será menos seguro.

Si se utiliza correctamente (sal personalizada, contraseña larga), garantiza una seguridad muy alta para el almacenamiento seguro.

---

### `Pbkdf2`

Considerada débil para los estándares actuales,  la forma **[Pbkdf2](https://en.wikipedia.org/wiki/PBKDF2)** para aplicar hash a la contraseña está definida como `EHashingMethod` de `2`. ASF usará la implementación de `Pbkdf2` utilizando `10000` iteraciones, longitud de hash `32` y la clave de cifrado como sal, con `SHA-256` como algoritmo hmac. Los bytes resultantes serán codificados como una cadena de caracteres **[base64](https://es.wikipedia.org/wiki/Base64)**.

ASF te permite especificar la sal para este método a través del **[argumento de la línea de comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-Line-Arguments-es-ES)** `--cryptkey`, el cual debes usar para máxima seguridad. Si decides omitirlo, ASF usará su propia clave que es **conocida** y está en el código de la aplicación, lo que significa que el hash será menos seguro.

---

## Recomendaciones de hashing

Si quieres usar un método de hash para almacenar algunos datos confidenciales, tal como `IPCPassword`, recomendamos usar `SCrypt` con sal personalizada, ya que proporciona una seguridad razonable contra intentos de fuerza bruta.

`Pbkdf2` solo se ofrece por razones de compatibilidad, principalmente porque ya tenemos una implementación funcional (y necesaria) de esta para otros casos en la plataforma de Steam (por ejemplo, códigos parentales). Se considera seguro, pero débil en comparación con otras alternativas (por ejemplo, `SCrypt`).