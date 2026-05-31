# Instalación

Si llegaste aquí por primera vez, ¡bienvenido! Estamos muy contentos de ver a otro viajero interesado en nuestro proyecto, aunque ten en cuenta que con un gran poder viene una gran responsabilidad - ASF es capaz de hacer muchas tareas relacionadas con Steam, siempre y cuando **te intereses lo suficiente para aprender cómo usarlo**. Ciertamente, leer la wiki, seguir nuestros consejos y aprender más acerca de varios conceptos de ASF eventualmente te recompensará con la habilidad única de usar una de las herramientas de Steam más poderosas al día de hoy.

Te recomendamos hacer **una cosa a la vez**. ASF abarca muchos aspectos diferentes, algunos de los cuales son algo triviales, otros pueden ser demasiado complejos. No necesitas entender o leer acerca de todo a la vez, y recomendamos que te lo tomes con calma. Relájate, toma una bebida de tu elección, dedica una hora de tu tiempo y sumérgete en nuestra clase - te prometemos que valdrá la pena tu tiempo.

Empecemos por lo básico- ASF es una aplicación de consola, esto significa que no mostrará automáticamente una interfaz gráfica como a las que estás acostumbrado. ASF es una aplicación universal que actúa principalmente como un servicio (daemon), y no como una aplicación de escritorio. Uno de sus principales usos considera ejecutarse en servidores, para lo que las aplicaciones de escritorio son completamente inadecuadas. Auqnue eso solo contempla la parte central del programa, porque realmente ASF **sí** incluye su propia interfaz gráfica - en forma de su frontend ASF-ui integrado, pero ya llegaremos a eso a su debido tiempo - solo se menciona para que no te asustes al ver una consola negra o algo así.

Una vez que obtengas los archivos binarios de ASF, el programa necesitará que lo configures, lo que especifica qué esperas  exactamente que ASF haga. Puedes iniciar el programa sin configuración, en este caso ASF se ejecutará con la configuración predeterminada, permitiendo que uses ASF-ui para la configuración iniciar, pero fuera de eso no hará mucho sin que tomes acciones previas.

Con eso bastará por ahora, ¡empecemos!

---

## Configuración de sistema operativo específico

En general, aquí está lo que haremos los próximos minutos:
- Instalaremos los **[prerrequisitos de .NET](#prerrequisitos-de-net)**.
- Posteriormente descargaremos la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** en la variante adecuada de sistema operativo específico.
- A continuación extraeremos el archivo en una nueva ubicación.
- Luego **[configuraremos ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**.
- Y finalmente, ejecutaremos ASF y veremos su magia.

Algunos de los pasos se explican solos, otros requerirán más atención de tu parte. No te preocupes, nosotros te cubrimos.

---

### Prerrequisitos de .NET

El primer paso es asegurarte de que tu sistema operativo puede siquiera ejecutar ASF correctamente. No necesitas saberlo, pero ASF está escrito en C#, basado en la plataforma .NET y podría requerir bibliotecas nativas que no están disponibles en tu plataforma. Piensa en ello como DirectX para los juegos en 3D, o el motor para arrancar tu coche.

Dependiendo de si usas Windows, Linux o macOS, tendrás diferentes requisitos. El documento de referencia es **[requisitos de .NET](https://learn.microsoft.com/es-es/dotnet/core/install/)**, pero por simplicidad también hemos detallado todos los paquetes necesarios a continuación, para que no tengas que leer todo, a menos que encuentres algún problema o tengas preguntas adicionales.

Es perfectamente normal que algunas (o incluso todas) las dependencias ya existan en tu sistema por haber sido instaladas por software de terceros que utilices. Aun así, ese no necesariamente es el caso, así que deberías ejecutar el instalador apropiado para tu sistema operativo - sin esas dependencias ASF no se ejecutará, y apenas obtendrás información útil que te diga lo que está mal.

Ten en cuenta que no necesitas hacer nada más para la compilación de sistema operativo específico, especialmente instalar .NET SDK o incluso runtime, puesto que el paquete de sistema operativo específico ya incluye todo eso. Solo necesitas los requisitos de .NET (dependencias) para ejecutar .NET runtime incluido en ASF - así que solo lo que especificamos a continuación, sin ninguna otra cosa adicional.

#### **[Windows](https://docs.microsoft.com/es-es/dotnet/core/install/windows)**:
- **[Microsoft Visual C++ Redistributable Update](https://learn.microsoft.com/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version)** (**[x64](https://aka.ms/vs/17/release/vc_redist.x64.exe)** para 64-bit, **[x86](https://aka.ms/vs/17/release/vc_redist.x86.exe)** para 32-bit o **[arm64](https://aka.ms/vs/17/release/vc_redist.arm64.exe)** para 64-bit ARM)
- Es altamente recomendado que te asegures de que todas las actualizaciones de Windows ya estén instaladas. Si no las tienes activadas, como mínimo necesitas **[KB2533623](https://support.microsoft.com/en-us/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)** y **[KB2999226](https://support.microsoft.com/en-us/help/2999226/update-for-universal-c-runtime-in-windows)**, aunque es posible que se requieran más actualizaciones. No necesitas preocuparte por eso si tu Windows está actualizado, o por lo menos lo bastante reciente.

#### **[Linux](https://docs.microsoft.com/es-es/dotnet/core/install/linux)**:
Los nombres de los paquetes dependen de la distribución de Linux que estés usando, hemos listado las más comunes. Puedes obtener todas con el administrador de paquetes nativos para tu sistema operativo (tal como `apt` para Debian o `yum` para CentOS). Estas son bibliotecas estándar que deberían estar disponibles independientemente de qué distribución estés usando, solo es cuestión de averiguar cómo se llaman en el entorno de tu elección.

- `ca-certificates` (certificados estándar SSL confiables para hacer conexiones HTTPS)
- `libc6` (`libc`)
- `libgcc-s1` (`libgcc1`, `libgcc`)
- `libicu` (`icu-libs`, última versión para tu distribución, por ejemplo `libicu76`)
- `libgssapi-krb5-2` (`libkrb5-3`, `krb5-libs`)
- `libssl3` (`libssl`, `openssl-libs`, última versión para tu distribución, al menos `1.1.X`)
- `libstdc++6` (`libstdc++`, en versión `5.0` o superior)
- `zlib1g` (`zlib`)

Al menos la mayoría de estas deberían estar disponibles nativamente en tu sistema. Por ejemplo, la instalación mínima de Debian normalmente solo requiere `libicu76`.

#### **[macOS](https://docs.microsoft.com/es-es/dotnet/core/install/macos)**:
- No necesitas nada específicamente, pero deberías tener instalada la última versión de macOS, por lo menos 12.0+

---

### Descargando

Ya que tengamos todas las dependencias requeridas, el siguiente paso es descargar la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)**. ASF está disponible en diversas variantes, pero te interesa el paquete que concuerde con tu sistema operativo y arquitectura. Por ejemplo, si usas `Win`dows de `64`-bits, entonces necesitas el paquete `ASF-win-x64`. Para más información acerca de las variantes disponibles, visita la sección de **[compatibilidad](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES)**. ASF también es capaz de ejecutarse en entornos para los que no compilamos un paquete de sistema operativo específico, tal como **32-bit Windows**, pero para eso necesitarás la **[configuración genérica](#configuración-genérica)**

![Recursos](https://i.imgur.com/Ym2xPE5.png)

Después de la descarga, empieza extrayendo el archivo zip en su propia carpeta. Si necesitas una herramienta específica para eso, **[7-zip](https://www.7-zip.org)** funcionará, pero todas las utilidades estándar como la extracción integrada en Windows o `unzip` de Linux/macOS también deberían funcionar sin problemas.

Recomendamos extraer ASF en **su propio directorio** y no a alguno existente que ya estés usando para algo más - eso es importante. ASF incluye la función de actualizaciones automáticas, que reemplaza sus propios archivos, y eso normalmente eliminará todos los archivos antiguos y no relacionados al actualizarse, lo que podría llevar a que pierdas cualquier cosa no relacionada que coloques en el directorio de ASF. Si tienes algún script adicional o archivos que quieras usar con ASF, eso no es problema, crea una carpeta dedicada para eso, siempre puedes poner ASF en una carpeta de nivel inferior.

Un ejemplo de la estructura se vería así:

```text
C:\ASF (donde pones tus cosas)
    ├── MyNotes.txt (opcional)
    ├── AsfMakeMeCoffeeScript.bat (opcional)
    ├── (...) (otros archivos de tu elección, opcional)
    └── Core (dedicado solo a ASF, donde extraes el archivo)
         ├── ArchiSteamFarm(.exe)
         ├── config
         ├── logs
         ├── plugins
         ├── www
         └── (...)
```

---

### Configuración

Ahora estamos listos para hacer el último paso, la configuración. ASF funciona con el concepto de "bots", cada bot normalmente es una cuenta de Steam que quieras usar en ASF. Puedes declarar tantos bots como quieras, pero para empezar nos centraremos solo en uno - normalmente tu cuenta principal. ASF también tiene archivos de configuración que no son del bot, el más importante es el archivo de configuración global, el cual afecta a todos los bots en la instancia.

La regla general es que **si no sabes o no entiendes algún ajuste, deberías dejarlo con su valor predeterminado, sin cambiar nada**. ASF ofrece incontables forma de configurar, personalizar y modificar casi todas sus funciones, pero como se mencionó anteriormente, intentar entenderlo en seguida es algo muy complicado que rápidamente te podría llevar a una gran confusión, si no es que **[arrastrarte directo al abismo](https://www.youtube.com/watch?v=KK3KXAECte4)**. En su lugar, recomendamos tener primero un ejemplo funcional, y solo entonces empezar a profundizar en las opciones adicionales, con ayuda de la página de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** en la wiki, y cambiando **una cosa a la vez**.

La configuración de ASF se puede hacer de varias maneras - a través de ASF-ui nuestro frontend integrado, el generador de configuraciones web, o manualmente. Esto se explica a detalle en la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**, así que consúltala si quieres información más detallada. Utilizaremos el generador de configuraciones web como punto de partida, porque funciona incluso si por alguna razón ASF-ui no inicia o no funciona correctamente.

Ve a la página de nuestro **[generador de configuraciones](https://justarchinet.github.io/ASF-WebConfigGenerator)** en tu navegador favorito. Recomendamos Chrome o Firefox, pero no debería importar siempre que tu navegador funciona para todo lo demás.

Después de abrir la página, cambia a la pestaña "Bot". Ahora deberías ver una página similar a la siguiente:

![Pestaña de bot](https://i.imgur.com/aF3k8Rg.png)

Si por cualquier motivo la versión de ASF que hayas descargado es más antigua que la que el generador de configuración usa por defecto, simplemente elige tu versión de ASF del menú desplegable. Esto puede ocurrir (raramente), ya que el generador de configuración puede ser usado para generar configuraciones para versiones más nuevas de ASF (prelanzamiento) que aún no han sido marcadas como estables. Has descargado la versión estable más reciente de ASF que ha sido verificado que funciona de forma confiable, así que podría ser un poco más antiguo que la última versión, lo cual no es adecuado para el uso por primera vez.

Empieza **poniéndole nombre a tu bot** en el campo resaltado en rojo, llamado `Name`. Este puede ser cualquier nombre que desees utilizar, tal como tu "nickname", nombre de la cuenta, un número, o cualquier otra cosa. Solo hay una palabra que no se puede utilizar, `ASF`, ya que esa palabra está reservada para el archivo de configuración global. Además de eso el nombre de tu bot no puede empezar con un punto (ASF intencionalmente ignora esos archivos). También recomendamos que evites usar espacios, puedes usar `_` como separador de palabras si es necesario - no es un requisito estricto, pero de lo contrario tendrás dificultades usando los comandos de ASF.

¿Ya decidiste el nombre de tu bot? Genial, en el siguiente paso **cambia la opción `Enabled` para que esté activa**, esta define si ASF debe iniciar automáticamente tu bot tras la ejecución (del programa). No hacer esto hará que ASF indique que tu bot está desactivado en el archivo de configuración, y esperará tu instrucción para iniciarlo, y eso no es lo que queremos hacer en este ejemplo.

Ahora bien, hay dos propiedades confidenciales a continuación: `SteamLogin` y `SteamPassword`. Puedes tomar otra decisión aquí - puedes poner tus datos de acceso a Steam en esas dos propiedades, o puedes decidir lo contrario, dejándolas vacías.

ASF requiere tus credenciales de inicio de sesión porque incluye su propia implementación del cliente de Steam y necesita los mismos detalles para iniciar sesión. Tus datos de inicio de sesión no se guardan en ningún lado, más que en tu PC en el directorio `config` de ASF (una vez hayas descargado la configuración generada). Nuestro generador de configuraciones es una aplicación basada en el cliente, lo que significa que todo lo que hagas en el sitio web de nuestro generador de configuraciones se ejecuta localmente en tu navegador para generar configuraciones de ASF válidas, sin que los datos que ingreses salgan de tu PC nunca, así que no hay necesidad de preocuparse por una filtración de datos confidenciales. Aun así, si por cualquier motivo no quieres introducir tus datos de acceso, lo entendemos, y puedes ponerlos manualmente después en los archivos generados, u omitirlos completamente y operar sin ellos.

Si decides introducir tus datos de acceso, ASF podrá iniciar sesión automáticamente durante el inicio, lo que en conjunto con el 2FA opcional te permitirá ejecutar todo con solo dos clics. Si decides omitirlas, entonces ASF **te pedirá** que introduzcas esos datos cuando sean requeridos - de esta forma no se guardarán en ningún lado, pero obviamente ASF no podrá funcionar sin tu ayuda. Depende de ti la forma que prefieras, y también puedes encontrar más información en la sección de **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**, como de costumbre.

Como nota adicional, también puedes dejar en blanco solo un campo, como sería `SteamPassword`. ASF será capaz de usar tus datos de acceso automáticamente, pero aún te pedirá la contraseña si es necesario (similar al cliente de Steam). Si por alguna razón estás usando el pin parental de 4 dígitos para desbloquear tu cuenta, también recomendamos introducirlo en el campo `SteamParentalPin`, aunque también puedes dejarlo vacío, y observar qué tan débil es esa protección, porque ASF también puede "descifrarla" en pocos segundos después de iniciar sesión. Ups.

Después de seguir lo anterior, una vez más, **nombre del bot**, **bot activado** y **datos de acceso**, tu página se verá similar a la siguiente:

![Pestaña de bot 2](https://i.imgur.com/yf54Ouc.png)

Ahora puedes presionar el botón "Descargar" y nuestro generador de configuración web creará un nuevo archivo `json` con el nombre que hayas elegido. Guarda ese archivo en el directorio `config` que se encuentra en la carpeta dentro de la que extrajiste el archivo zip en el paso anterior.

¡Felicidades! Acabas de terminar la configuración más básica de un bot en ASF. Hay mucho más por descubrir, pero por ahora esto es todo lo que necesitas.

---

### Ejecutando ASF

Sé que hasta estado esperando este momento, y no podemos retenerte más tiempo, porque ya estás listo para ejecutar el programa por primera vez. Simplemente haz doble clic en el ejecutable `ArchiSteamFarm` ubicado en el directorio de ASF. También puedes iniciarlo desde la consola.

Ahora sería un buen momento para revisar nuestra sección de **[comunicación remota](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Remote-communication-es-ES)** si te preocupa lo que ASF está programado para hacer, especialmente acciones que realizará en tu nombre, tal como unirse de forma predeterminada a nuestro grupo de Steam. Más adelante puedes desactivar las funcionalidades que desees si no te gustan, ASF viene con valores predeterminados sensatos, y tuvimos que tomar algunas decisiones sobre el uso general que aplica para la mayoría de nuestros usuarios, así como nuestra opinión del programa en principio.

Suponiendo que todo salió bien, que mayormente implica instalar todas las dependencias requeridas mencionadas en el primer paso, y configurar ASF según el tercero, ASF debería ejecutarse correctamente, descubrir tu primer bot, e intentar iniciar sesión:

![ASF](https://i.imgur.com/u5hrSFz.png)

Es muy probable que ASF aún te solicite un dato -  2FA para acceder a la cuenta (a menos que deshabilites SteamGuard completamente, en cuyo caso no). Simplemente sigue las instrucciones en pantalla, puedes proporcionar el código del autenticador o correo electrónico, o aceptar la confirmación en la aplicación móvil.

¿Algo salió mal?

#### ASF no inicia en absoluto, no hay ventana de consola

Ya sea que te falten requisitos de .NET, o descargaste la variante de ASF incorrecta para tu máquina. Si no sabes qué está mal, revisa nuestras **[preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES#asf-no-inicia-la-ventana-del-programa-se-cierra-inmediatamente)** para una posible forma de averiguar el problema exacto, y si todavía estás atascado, contacta con nuestro **[soporte](https://github.com/JustArchiNET/ArchiSteamFarm/blob/main/.github/SUPPORT.md)**.

#### No hay bots definidos

No pusiste la configuración generada en el directorio `config`. Algunos otros errores comunes en este paso pueden incluir cambiar manualmente la extensión de `.json` a algo como `.txt`, y a algunos sistemas operativos (por ejemplo, Windows) les gusta ocultar las extensiones comunes por defecto, así que asegúrate de que tu archivo está en el lugar y con el nombre correctos.

#### No se ha iniciado este bot porque está desactivado en el archivo de configuración

Has olvidado activar la opción `Enabled` que le indica a ASF que inicie tu bot automáticamente. A menos que esa sea tu intención, pero ya deberías saber como ejecutar comandos, solamente usa `start` para iniciar tu bot después de ese mensaje.

#### `InvalidPassword`

Lo más probable es que tus datos de acceso sean incorrectos. Revisa `SteamLogin` y `SteamPassword` en el archivo de configuración generado, si son erróneos, corrígelos regresando al paso anterior de la configuración. Si todavía tienes problemas, intenta usar los mismos datos de acceso en tu cliente de Steam - también debería fallar el inicio de sesión, y tal vez de esta forma obtendrás más información sobre lo que está mal.

#### ¿Todo bien?

Después de la etapa de inicio de sesión, asumiendo que tus datos son correctos, iniciarás sesión con éxito, y ASF empezará a recolectar cromos usando la configuración predeterminada que no hayas cambiado hasta ahora:

![ASF 2](https://i.imgur.com/Cb7DBl4.png)

Esto prueba que ASF está haciendo su trabajo con éxito en tu cuenta, ahora puedes minimizar el programa y hacer algo más. ¡Adelante, te lo mereces, tal vez rellena esa bebida al menos!

Recolectar cromos es tema para otro artículo extenso, pero en principio: después del tiempo suficiente (dependiendo del **[rendimiento](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Performance-es-ES)**), verás que lentamente obtienes cromos de Steam. Por supuesto, para que eso pase debes tener juegos válidos para recolectar, lo que se muestra como "puedes obtener X cromos más jugando este juego" en tu **[página de insignias](https://steamcommunity.com/my/badges)** - si no hay juegos para recolectar, entonces ASF indicará que no hay nada por hacer, como se menciona en nuestras **[preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES#qué-es-asf)**, en donde se responde la pregunta más común que la gente tiene en este punto, preguntándose por qué a pesar de tener 14 juegos en su cuenta, ASF afirma que no hay nada para recolectar - no, no es un error.

Esto concluye nuestra guía de configuración básica. Como en cualquier juego RPG, has terminado el tutorial, y ahora te dejamos el mundo de ASF para explorar. Por ejemplo, puedes decidir si quieres hacer más ajustes a ASF, o dejarlo hacer su trabajo en la configuración predeterminada. Cubriremos algunos detalles básicos adicionales por si quieres leer un poco más, y luego te dejaremos toda la wiki para que descubras.

---

### Configuración extendida

#### Recolectar varias cuentas al mismo tiempo

ASF soporta la recolección de más de una cuenta a la vez, lo cual es su función principal. Puedes añadir más cuentas a ASF generando más archivos de configuración de bots, exactamente del mismo modo que generaste el primero hace algunos minutos. Solo debes de asegurarte de dos cosas:

- Usar un nombre de bot único, si ya nombraste tu primer bot como `MainAccount`, no puedes tener otro con el mismo nombre.
- Datos de inicio de sesión válidos, tales como `SteamLogin`, `SteamPassword` y `SteamParentalCode`

En otras palabras, simplemente ve a configuración de nuevo y haz exactamente lo mismo, solo que para tu segunda o tercera cuenta. Recuerda usar nombres únicos para todos tus bots, para no sobreescribir configuraciones existentes.

---

#### Cambiar la configuración

En nuestro generador de configuraciones, puedes cambiar ajustes existentes exactamente de la misma forma - generando un nuevo archivo de configuración. Haz clic en "mostrar configuración avanzada" y ve lo que hay para descubrir. En este ejemplo, cambiaremos el ajuste `CustomGamePlayedWhileFarming`, que permite establecer un nombre personalizado para que se muestre cuando ASF está recolectando, en lugar de mostrar el nombre real del juego.

Analicemos esto primero. Si ejecutas ASF y empieza a recolectar, en la configuración predeterminada, verás que tu cuenta de Steam está en un juego:

![Steam](https://i.imgur.com/1VCDrGC.png)

Eso tiene sentido, después de todo ASF le acaba de decir a Steam que estamos jugando un juego, pues necesitamos los cromos, ¿cierto? ¡Pero podemos personalizar esto! Muestra la configuración avanzada si aún no lo has hecho, luego busca `CustomGamePlayedWhileFarming`. Simplemente pon cualquier texto personalizado que quieras mostrar ahí, tal como "Recolectando cromos":

![Pestaña de bot 3](https://i.imgur.com/gHqdEqb.png)

Ahora descarga el nuevo archivo de configuración exactamente de la misma manera, luego **sobrescribe** tu archivo de configuración previo con el nuevo. También puedes eliminar tu archivo de configuración anterior y poner el nuevo en su lugar.

ASF es bastante inteligente y debería notar que cambiaste la configuración, que entonces debería tomar y aplicar automáticamente, sin reiniciar el programa. Si por alguna razón eso no ocurre, puedes reiniciar el programa para asegurar que tu nueva configuración sea tomada en cuenta. Después, deberías notar que ASF ahora muestra tu texto personalizado:

![Steam 2](https://i.imgur.com/vZg0G8P.png)

Esto confirma que editaste exitosamente tu configuración. De la misma manera puedes cambiar las propiedades globales de ASF, cambiando de la pestaña de bot a la pestaña "ASF", y luego descargando el archivo de configuración `ASF.json` generado y poniéndolo en tu directorio `config`.

Editar tus configuraciones de ASF se puede hacer más fácilmente usando nuestro frontend ASF-ui, el cual será explicado más adelante.

---

#### Usando ASF-ui

Como mencionamos anteriormente, ASF es una aplicación de consola y no ejecuta una interfaz gráfica por defecto. Sin embargo, estamos trabajando en el frontend **[ASF-ui](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-es-ES#asf-ui)** para nuestra interfaz IPC, la cual puede ser una manera muy decente y amigable para acceder a varias funciones de ASF.

Para poder usar ASF-ui, necesitas tener `IPC` habilitado, que es la opción predeterminada, así que a menos que la deshabilites manualmente, ya está activa. Una vez que inicies ASF, deberías poder comprobar que inició automáticamente de forma correcta la interfaz IPC:

![IPC](https://i.imgur.com/ZmkO8pk.png)

IPC, en resumen, es el servidor web de ASF que se inicia localmente en tu máquina permitiéndote interactuar con ASF usando tu navegador web favorito. Suponiendo que se inició correctamente, puedes acceder a la interfaz IPC de ASF haciendo clic en **[este](http://localhost:1242)** enlace, siempre y cuando ASF se esté ejecutando en la misma máquina. Puedes usar ASF-ui para varios propósitos, por ejemplo, editar los archivos de configuración o enviar **[comandos](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-es-ES)**. No dudes en echar un vistazo para descubrir todas las funcionalidades de la interfaz de usuario de ASF.

![ASF-ui](https://raw.githubusercontent.com/JustArchiNET/ASF-ui/main/.github/previews/bots.png)

---

### Sumario

Has configurado ASF con éxito para usar tus cuentas de Steam y ya lo has personalizado un poco a tu gusto. Si seguiste toda nuestra guía, también lograste modificar ASF a través de nuestra interfaz ASF-ui y empezaste a descubrir sus funcionalidades. Esto concluye nuestro tutorial, pero te dejamos algunos consejos adicionales para temas que te podrían interesar, "misiones secundarias", si insistes:

- Nuestra sección de  **[configuración](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)** explicará lo que hacen **todos** los diferentes ajustes que viste, y lo que ASF tiene para ofrecer. Solo recuerda hidratarte mientras lees, has sido advertido.
- Si te encuentras con algún problema o tienes alguna pregunta genérica, considera revisar nuetras **[preguntas frecuentes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ-es-ES)**, que deberían cubrir todo, o al menos la gran mayoría de las preguntas y problemas que podrías tener.
- Si quieres aprender todo acerca de ASF y cómo puede hacer tu vida más fácil, dirígete al resto de **[nuestra wiki](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Home-es-ES)**. Usa la barra lateral del lado derecho para seleccionar el tema que te interese.
- Y finalmente, si nuestro programa te resulta útil y aprecias la increíble cantidad de trabajo que se le ha dedicado, también puedes considerar hacer una pequeña **[donación](https://github.com/JustArchiNET/ArchiSteamFarm?tab=readme-ov-file#donate)** a nuestra causa. ASF es un trabajo por amor, hemos trabajado duro en nuestro tiempo libre los últimos 10 años y más, para hacer posible esta experiencia para ti, y estamos muy orgullosos de ello - incluso $1 es muy apreciado y muestra que te importa. En cualquier caso, ¡diviértete!

---

## Configuración genérica

Este apéndice es para usuarios avanzados que quieran configurar ASF para ejecutarse en su variante **[genérica](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES#genérico)**. Aunque es más problemática en su uso que las **[variantes de sistema operativo específico](#configuración-de-sistema-operativo-específico)**, también viene con beneficios adicionales.

Quieres usar la variante `generic` principalmente cuando:
- Estás usando un sistema operativo para el que no compilamos un paquete de sistema operativo específico (tal como Windows de 32 bits).
- Ya tienes .NET Runtime/SDK, o quieres instalar y usar uno.
- Quieres minimizar el tamaño de la estructura de ASF y la huella de memoria al manejar los requisitos de runtime por ti mismo.
- Quieres usar un **[plugin](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Plugins-es-ES)** personalizado lo que requiere una configuración `generic` de ASF para ejecutarse adecuadamente (debido a dependencias nativas faltantes)

Por supuesto, también puedes usarla en cualquier otro escenario que quieras, pero los anteriores son los que tienen más sentido.

Sin embargo, ten en cuenta que la configuración genérica viene con un giro - **tú** estás a cargo del .NET runtime en este caso. Esto significa que si tu .NET SDK (runtime) no está disponible, está desactualizado o roto, ASF simplemente no funcionará. Es por eso que no recomendamos esta configuración para usuarios casuales, ya que necesitarías asegurarte de que tu .NET SDK (runtime) coincide con los requisitos de ASF y que puede ejecutar, contrario a que **nosotros** nos aseguremos que nuestro .NET runtime incluido en ASF lo pueda hacer.

Para el paquete `generic`, puedes seguir la guía anterior para sistemas operativos específicos, con dos pequeños cambios. Además de instalar los requisitos de .NET, también querrás instalar .NET SDK, y en lugar de descargar y tener el archivo ejecutable `ArchiSteamFarm(.exe)` para sistema operativo específico, ahora solo descargarás y tendrás un binario `ArchiSteamFarm.dll` genérico. Todo lo demás es exactamente igual.

Con pasos adicionales:
- Instalar los **[prerrequisitos .NET](#prerrequisitos-de-net)**.
- Instalar **[.NET SDK](https://www.microsoft.com/net/download)** (o al menos ASP.NET Core y .NET runtimes) apropiado para tu sistema operativo. Probablemente querrás usar un instalador. Dirígete a **[requisitos de runtime](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-es-ES#requisitos-de-runtime)** si no estás seguro de qué versión instalar.
- Descarga la **[última versión de ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** en su variante `generic`.
- Extraer el archivo en una nueva ubicación.
- **[Configurar ASF](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-es-ES)**
- Ejecuta ASF ya sea usando un script auxiliar o ejecutando `dotnet /path/to/ArchiSteamFarm.dll` manualmente desde tu shell favorito.

La variante genérica de ASF no tiene binario para un sistema operativo específico, después de todo se llama `generic` genérica por una razón - es una compilación que sin importar la plataforma puede funcionar en todas partes, así que no esperes encontrar un archivo `exe`.

Por eso la hemos incluido con scripts de ayuda (tales como `ArchiSteamFarm.cmd` para Windows y `ArchiSteamFarm.sh` para Linux/macOS), que se encuentran junto al binario `ArchiSteamFarm.dll`. Puedes usar esos si no quieres ejecutar manualmente el comando `dotnet`.

Obviamente, los scripts de ayuda no funcionarán si no instalaste .NET SDK y no tienes `dotnet` ejecutable disponible en tu `PATH`. Su uso también es completamente opcional, siempre puedes usar `dotnet /path/to/ArchiSteamFarm.dll` manualmente si lo deseas, ya que por debajo, eso es exactamente lo que hacen los scripts de todos modos.