#the location paket will place *.nupkg files when pack command is run
nupkgOutputDir := ./publish
bootstrapper := paket.bootstrapper.exe

#appends branch name to output dir if this is a git repo
branch := $(shell git rev-parse --abbrev-ref HEAD 2>/dev/null)
ifdef branch
nupkgOutputDir := $(nupkgOutputDir)/$(branch)
endif

all: clean test

updatepaket:
	@mkdir -p .paket \
		&& curl -o .paket/$(bootstrapper) -L \
		https://github.com/fsprojects/Paket/releases/download/0.38.4/$(bootstrapper) \
		&& mono .paket/$(bootstrapper) prerelease

install: updatepaket
	@mono .paket/paket.exe install

build:
	@xbuild /nologo /v:q /property:GenerateFullPaths=true

#flags for good developmenet experience with stack trace line numbers and filenames
test: build
	@mono \
		--debug \
		--runtime=v4.0 \
		--optimize=-inline \
		packages/NUnit.Runners/tools/nunit-console.exe \
		**/bin/**/*Tests.dll \
		-stoponerror \
		-nologo \
		-config=Debug

#cleans out bin and obj
clean:
	@find . -type d \( -name "bin" -o -name "obj" \) | xargs rm -rf

#runs paket pack command on paket.template files
publish:
	@mono .paket/paket.exe pack output "$(nupkgOutputDir)" \
		&& echo "Published to $(nupkgOutputDir)"

.PHONY: all updatepaket install build test clean publish
