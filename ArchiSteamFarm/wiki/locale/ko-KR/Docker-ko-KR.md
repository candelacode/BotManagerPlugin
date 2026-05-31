# 도커

ASF is available as **[docker container](https://www.docker.com/what-container)**. Our docker packages are currently available on **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** as well as **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

It's important to note that running ASF in Docker container is considered **advanced setup**, which is **not needed** for vast majority of users, and typically gives **no advantages** over container-less setup. If you're considering Docker as a solution for running ASF as a service, for example making it start automatically with your OS, then you should consider reading **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** section instead and set up a proper `systemd` service which will be **almost always** a better idea than running ASF in a Docker container.

Running ASF in Docker container usually involves **several new problems and issues** that you'll have to face and resolve yourself. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. This section is mostly for valid use cases of very complex setups, for example in regards to advanced networking or security beyond standard sandboxing that ASF comes with in `systemd` service (which already ensures superior process isolation through very advanced security mechanics). For those handful amount of people, here we explain better ASF concepts in regards to its Docker compatibility, and only that, you're assumed to have adequate Docker knowledge yourself if you decide to use it together with ASF.

---

## 태그

ASF is available through several types of **[tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `main`

Generic build of ASF that is built from the very latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. It's the highest level of bugged software dedicated to developers and advanced users for development purposes. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often changes (and stuff being broken). It's here to mark current state of the ASF project, which is not necessarily guaranteed to be stable or tested, just like pointed out in our release cycle. **This tag should not be used in any production environment**. Useful for verification whether particular commit fixed the issue you're encountering, without waiting even for a pre-release with that commit.


### `released`

Generic build of ASF that always points to the latest **[released](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF version, including pre-releases. Compared to `main` tag, image here is being updated each time a new GitHub tag is pushed. 안정적이면서도 새로운, 최첨단에 있기를 좋아하는 고급 사용자를 위한 것입니다. In practice, it works the same as rolling tag pointing to the most recent `A.B.C.D` release at the time of pulling. Please note that using this tag is equal to using our **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.

### `안정 버전`

Generic build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. Compared to `released` tag, image here is being updated once new stable version of ASF is made available. Recommended for people that are looking for stable variant of `released` tag mentioned above.

### `latest`

OS-specific build of ASF that always points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. In comparison with others, this is the **only tag** that includes ASF auto-updates. The objective of this tag is to provide a sane default Docker container that is capable of running self-updating, OS-specific build of ASF. 이 때문에 가능한만큼 자주 업데이트 될 필요가 없습니다. 포함된 ASF 버전은 필요하다면 스스로 업데이트될 수 있습니다.

Of course, `UpdatePeriod` can be safely turned off (set to `0`), but in this case you should probably use `stable` release instead. Likewise, you can modify default `UpdateChannel` in order to track pre-releases instead if you'd like to.

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. This is because newer (updated) ASF version might also require newer runtime than the one the image could possibly be built with, which would otherwise require image to be re-built from scratch, nullifying the planned use-case.

### `A.B.C.D`

Generic build of ASF that points to the fixed ASF version matching the tag. In comparison with above tags, this tag is completely frozen, which means that the image here won't be updated once published. 최초 릴리스 후 한번도 건드리지 않은 GitHub 릴리스와 유사하게 동작하고, 안정적이고 동결된 환경을 보장합니다. Typically you should use this tag when you want to use some specific ASF release and expect deterministic outcome of the build (e.g. managing ASF versions yourself instead).

---

## 어떤 태그가 최선입니까?

찾고 있는 것에 따라 다릅니다. 대부분의 사용자에게 `latest` 태그가 최선입니다. 이는 서비스로 되어있는 특별한 도커 컨테이너에 담겨있을 뿐 데스크탑 ASF가 제공하는 것을 정확하게 동일하게 제공합니다. However, this is not necessarily how docker should be used - normally you're expected to rebuild your containers and not run them forever, and in this case you should consider `stable` or `released` tag, which follow docker guidelines. Lastly, if you want to run some fixed ASF version instead, then naturally `A.B.C.D` releases are what you're looking for.

We generally discourage trying `main` builds, as those are here for us to mark current state of ASF project. 그 상태는 어떤것도 정상작동을 보장하지 않지만, ASF 개발에 관심이 있다면 시도해보는 것도 좋습니다.

---

## 아키텍쳐

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` and `arm64`. 더 많은 정보는 **[호환성](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-ko-KR)** 항목을 참고하십시오.

Our tags are using multi-platform manifest, which means that Docker installed on your machine will automatically select the proper image for your platform when pulling the image. If by any chance you'd like to pull a specific platform image which doesn't match the one you're currently running, you can do that through `--platform` switch in appropriate docker commands, such as `docker run`. See docker documentation on **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** for more info.

---

## 사용법

완전한 참조는 **[도커 공식 문서](https://docs.docker.com/engine/reference/commandline/docker)**를 참고하시고, 이 가이드에서는 간단한 사용법만 다룹니다. 더 깊이 공부하는 것도 좋습니다.

### 안녕하세요 ASF!

먼저 도커가 정상적으로 작동하는지 확인해야합니다. 이것이 ASF의 "Hello World!" 입니다.

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` 으로 당신의 새로운 ASF 도커 컨테이너를 생성하고 전경에서 실행되도록 합니다(`-it`). `--pull always` ensures that up-to-date image will be pulled first, and `--rm` ensures that our container will be purged once stopped, since we're just testing if everything works fine for now.

모든것이 성공적으로 끝나면, 모든 레이어를 당기고 컨테이너를 시작한 뒤 ASF가 정상적으로 시작해서 정의된 봇이 없다고 알리고 있음을 알게 됩니다. ASF가 도커에서 정상적으로 작동하고 있습니다. Hit `CTRL+C` to terminate the ASF process and therefore also the container.

명령어를 자세히 봤다면 태그를 선언하지 않았음을 알게 되었을 겁니다. 태그는 자동으로 기본값인 `latest` 가 됩니다. If you want to use other tag than `latest`, for example `released`, then you should declare it explicitly:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## 볼륨 사용

ASF를 도커 컨테이너에서 사용하고 있다면 프로그램 자체를 환경설정할 필요가 있습니다. 다양한 방법으로 할 수 있지만, 추천하는 것은 로컬 기기에 ASF `config` 디렉토리를 만들어서 ASF 도커 컨테이너에 공유 볼륨으로 마운트 하는 것입니다.

예를 들어, 당신의 ASF 환경설정 폴더가 `/home/archi/ASF/config` 디렉토리에 있다고 가정합니다. 이 디렉토리는 핵심 `ASF.json`과 실행하려는 봇이 담겨 있습니다. 이제 할일은 단순히 이 디렉토리를 도커 컨테이너에 공유볼륨으로 붙이는 것입니다. ASF는 여기에 환경설정 디렉토리(`/app/config`)가 있다고 생각합니다.

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

그러면 끝입니다. 이제 ASF 도커 컨테이너는 로컬 기기에 있는 공유 디렉토리를 읽기-쓰기 모드로 사용하고, 이는 ASF를 설정하는데 필요한 전부입니다. In similar, way you can mount other volumes that you'd like to share with ASF, such as `/app/logs` or `/app/plugins`.

물론, 이는 우리가 원하는 바를 달성하기 위한 하나의 방법일뿐이고, 자신만의 `Dockerfile`을 만들어서 환경설정 파일을 ASF 도커 컨테이너 안의 `/app/config` 디렉토리로 복사하는 등 당신이 하려는 것을 막을수 있는 것은 없습니다. 이 가이드에서는 기본적인 것만을 다룹니다.

### 볼륨 권한

ASF container by default is initialized with default `root` user, which allows it to handle the internal permissions stuff and then eventually switch to `asf` (UID `1000`) user for the remaining part of the main process. While this should be satisfying for the vast majority of users, it does affect the shared volume as newly-generated files will be normally owned by `asf` user, which may not be desired situation if you'd like some other user for your shared volume.

There are two ways you can change the user ASF is running under. The first one, recommended, is to declare `ASF_UID` environment variable with target UID you want to run under. Second, alternative one, is to pass `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, which is directly supported by docker.

You can check your `uid` for example with `id -u` command, then declare it as specified above. For example, if your target user has `uid` of 1001:

```shell
docker run -it -e ASF_UID=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternatively, if you understand the limitations below
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

The difference between `ASF_UID` and `--user` flag is subtle, but important. `ASF_UID` is custom mechanism supported by ASF, in this scenario docker container still starts as `root`, and then ASF startup script starts main binary under `ASF_UID`. When using `--user` flag, you're starting whole process, including ASF startup script as given user. First option allows ASF startup script to handle permissions and other stuff automatically for you, resolving some common issues that you might've caused, for example it ensures that your `/app` and `/asf` directories are actually owned by `ASF_UID`. In second scenario, since we're not running as `root`, we can't do that, and you're expected to handle all of that yourself in advance.

If you've decided to use `--user` flag, you need to change ownership of all ASF files from default `1000` to your new custom user. You can do so by executing command below:

```shell
# Execute only if you're not using ASF_UID
docker exec -u root asf_container_name chown -hR 1001 /app /asf
```

This has to be done only once after you created your container with `docker run`, and only if you decided to use custom user through `--user` docker flag. Also don't forget to change `1001` argument in command above to the `UID` you actually want to run ASF under.

### Volume with SELinux

If you're using SELinux in enforced state on your OS, which is the default for example on RHEL-based distros, then you should mount the volume appending `:Z` option, which will set correct SELinux context for it.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

This will allow ASF to create files targetting the volume while inside docker container.

---

## Multiple instances synchronization

ASF includes support for multiple instances synchronization, as stated in **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** section. When running ASF in docker container, you can optionally "opt-in" into the process, in case you're running multiple containers with ASF and you'd like for them to synchronize with each other.

By default, each ASF running inside a docker container is standalone, which means that no synchronization takes place. In order to enable synchronization between them, you must bind `/tmp/ASF` path in every ASF container that you want to synchronize, to one, shared path on your docker host, in read-write mode. This is achieved exactly the same as binding a volume which was described above, just with different paths:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# 이제 모든 ASF 컨테이너가 서로 동기화됩니다.
```

We recommend to bind ASF's `/tmp/ASF` directory also to a temporary `/tmp` directory on your machine, but of course you're free to choose any other one that satisfies your usage. Each ASF container that is expected to be synchronized should have its `/tmp/ASF` directory shared with other containers that are taking part in the same synchronization process.

As you've probably guessed from example above, it's also possible to create two or more "synchronization groups", by binding different docker host paths into ASF's `/tmp/ASF`.

Mounting `/tmp/ASF` is completely optional and actually not recommended, unless you explicitly want to synchronize two or more ASF containers. We do not recommend mounting `/tmp/ASF` for single-container usage, as it brings absolutely no benefits if you expect to run just one ASF container, and it might actually cause issues that could otherwise be avoided.

---

## 명령줄 인자

ASF는 환경변수를 통해 **[명령줄 인자](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-ko-KR)** 를 도커 컨테이너로 넘겨줄 수 있습니다. 지원하는 스위치를 위해서는 특별한 환경변수를, 그 외에는 `ASF_ARGS` 를 사용해야 합니다. `docker run` 에 `-e` 스위치를 붙이면 됩니다. 다음은 예시입니다.

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

이렇게 하면 `--cryptkey` 인자 뿐 아니라 다른 인자들도 도커 컨테이너 내부에서 실행되는 ASF 프로세스로 전달할 것입니다. Of course, if you're advanced user, then you can also modify `ENTRYPOINT` or add `CMD` and pass your custom arguments yourself.

Unless you want to provide custom encryption key or other advanced options, usually you don't need to include any special environment variables, as our docker containers are already configured to run with a sane expected default option of `--no-restart`, so that flag does not need to be specified explicitly in `ASF_ARGS`.

---

## IPC

Assuming you didn't change the default value for `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's already enabled. However, you must do two additional things for IPC to work in Docker container. Firstly, you must use `IPCPassword` or modify default `KnownNetworks` in custom `IPC.config` to allow you to connect from the outside without using one. Unless you really know what you're doing, just use `IPCPassword`. Secondly, you have to modify default listening address of `localhost`, as docker can't route outside traffic to loopback interface. 모든 인터페이스를 리슨하는 설정값의 예시입니다. `http://*:1242`. 물론 로컬 LAN이나 VPN 네트워크 같은 더 제한적인 바인딩을 사용할 수도 있지만, 외부에서 라우팅 가능해야 합니다. `localhost`는 게스트 기기안에서만 라우팅하므로 이것이 불가능합니다.

위와 같이 하려면, 아래와 같은 **[사용자 설정 IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR#custom-configuration)**를 사용해야 합니다.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

IPC를 루프백이 아닌 인터페이스에 설정하고 나면, `-P` 나 `-p` 스위치를 사용해서 도커에게 ASF의 `1242/tcp` 포트를 알려주어야 합니다.

예를 들어, 이 명령어는 ASF의 IPC 인터페이스를 호스트 기기에 열 것입니다.

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

모든 것을 정확하게 설정했다면 위의 `docker run` 명령어는 호스트 기기의 **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ko-KR)** 인터페이스가 게스트 기기로 리다이렉트된 표준 `localhost:1242` 라우트에서동작하도록 할 것입니다. 이 라우트를 더 많이 노출하지 않음을 알아 두십시오. 연결은 오직 도커 호스트안에서만 이루어지고 안전하게 유지됩니다. Of course, you can expose the route further if you know what you're doing and ensure appropriate security measures.

---

### 완전한 예제

위의 지식을 모두 합치면 완전한 설치 예시는 다음과 같습니다.

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always --restart unless-stopped justarchi/archisteamfarm
```

This assumes that you'll use a single ASF container, with all ASF config files in `/home/archi/ASF/config`. You should modify the config path to the one that matches your machine. It's also possible to provide custom plugins for ASF, which you can put in `/home/archi/ASF/plugins`. 다음과 같은 `IPC.config` 를 환경설정 디렉토리에 넣기로 결정했다면 추가로 IPC 사용도 가능합니다.

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

You can achieve the same effect of `docker run` command above by using the following `docker compose` config:

```yaml
version: "3.8"
services:
  asf:
    image: justarchi/archisteamfarm
    container_name: asf
    restart: unless-stopped
    ports:
      - "127.0.0.1:1242:1242"
      - "[::1]:1242:1242"
    volumes:
      - /home/archi/ASF/config:/app/config
      - /home/archi/ASF/plugins:/app/plugins
```

From things other than we already discussed above, we've added `--restart unless-stopped` to both examples above in order to start this container automatically after restart of your machine. Feel free to remove/change it to suit your needs.

---

## 프로 팁

ASF 도커 컨테이너가 준비되어있다면 `docker run`를 매번 실행할 필요가 없습니다. `docker stop asf`와 `docker start asf`로 ASF 도커 컨테이너를 쉽게 멈추고 시작할 수 있습니다. Keep in mind that if you're not using `latest` tag then using up-to-date ASF will still require from you to `docker stop`, `docker rm` and `docker run` again. 이는 매 버전마다 새로운 ASF 도커 이미지로부터 다시 빌드해야 하기 때문입니다. In `latest` tag, ASF has included capability to auto-update itself, so rebuilding the image is not necessary for using up-to-date ASF (but it's still a good idea to do it from time to time in order to use fresh .NET runtime dependencies and the underlying OS, which might be needed when jumping across major ASF version updates).

위에서 암시하였듯이, `latest` 가 아닌 ASF 태그는 스스로 자동 업데이트하지 않습니다. 즉, **당신이** 최신의 `justarchi/archisteamfarm` 저장소를 사용할 주체입니다. 보통 앱이 실행중에는 코드를 건드려서는 안되기 때문에 많은 장점을 갖지만, 도커 컨테이너에 있는 ASF는 걱정할 필요가 없다는 편리함도 있습니다. 좋은 사례와 정확한 도커 사용례를 잘 살핀다면 우리가 추천하는 것은 `latest` 태그가 아닌 `released` 태그입니다. 하지만 그게 귀찮고 ASF가 동작도 잘하고 자동 업데이트도 하길 원하면 `latest` 태그가 그 답입니다.

보통 ASF 도커 컨테이너는 `Headless: true` 일반 설정상태로 실행해야 합니다. 이는 ASF에게 세부적인 내용이 빠져있어도 당신이 줄 수 없으며 묻지 말 것을 알립니다. 물론 초기 설치단계에서는 이 옵션을 `false`로 해서 쉽게 설정할 수 있지만, 장기적으로는 ASF 콘솔에 매여있지 않으므로 ASF에게 이를 알리고 필요가 있으면 `input` **[명령어](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ko-KR)** 를 사용하는 것이 맞습니다. 이렇게 해서 ASF는 일어나지 않을 사용자 입력을 무한히 기다리지 않을 수 있고 이에 소요되는 자원낭비를 막을 수 있습니다. It will also allow ASF to run in non-interactive mode inside container, which is crucial e.g. in regards to forwarding signals, making it possible for ASF to gracefully close on `docker stop asf` request.