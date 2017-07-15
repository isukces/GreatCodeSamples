# Testing code with XUnit
## Nuget packages

Include `xunit` package in your testing assembly project. In order to run test directly under VisualStudio use `xunit.runner.visualstudio` package. So:

```
install-package xunit
install-package xunit.runner.visualstudio
```
## Testing code overview
Use public classes containing public static methods or instance methods. Methods decorated with `Fact` or `Theory` attribute are discovered by testing engine. Testing methods name has to indicate what feature is tested. Usualy it contains `Should` prefix i.e. `Should_check_divide_by_zero`. I prefer to add some number prefix thath helps me to find method in class when there is many of testing methods in single class i.e. `T132_Should_check_divide_by_zero`. 
## Testing signed assembly
### How obtain public key from snk file

Assume that assembly is signed with keys located in `key.snk` file. Open windows console in the same folder as key.snk.
`sn.exe` location depends on framework version and in my case is `c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\`

```
Path=c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\;%PATH%
sn.exe -p key.snk ExportFileName.PublicKey
```
This will export public key in binary form. If you need text representation in BCD notation use.
```
sn.exe -tp ExportFileName.PublicKey
```
This will display on console text similar to 
```
Public key (hash algorithm: sha1):
0024000004800000940000000602000000240000525341310004000001000100b18cc8b959a8c8
2317fb2ed2af0bcb14e0219d14ec9cf4bea70c6094eff7af82b297ddd95a81bb825c6c2ea84353
9d05b9c1a6501ba0361adee5a45abac350efdb398b9d06b9e81131fe8cf040de32ff847e9499c9
713f2d91f227790e3fa868194f421b54eb505df310beff07b23a417bb096310becd9a23dd1f974
f9b8fbde

Public key token is aba3f69a62db871b

```
### How to obtain access to internal members in another assembly
I'ts useful to have access to internal classes and class members of tested assembly from testing assembly. In order to expose internal members to specific assemblies decorate tested library or program with following attribute
```
[assembly: InternalsVisibleTo("UnitTests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b18cc8b959a8c82317fb2ed2af0bcb14e0219d14ec9cf4bea70c6094eff7af82b297ddd95a81bb825c6c2ea843539d05b9c1a6501ba0361adee5a45abac350efdb398b9d06b9e81131fe8cf040de32ff847e9499c9713f2d91f227790e3fa868194f421b54eb505df310beff07b23a417bb096310becd9a23dd1f974f9b8fbde")]
```
Argument of InternalsVisibleTo is assembly name that needs access to internal members. If it has strong name then its public key must be also included. Use BCD from of public key that was displayed by sn.exe. Note that sn.exe output contains unnecessary spaces that needs to be removed.

