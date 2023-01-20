# StateMountedSambaShare
<div dir="rtl">

![net version](https://img.shields.io/badge/.NET%20Core-3.1-blue)
</div>

## Fatures 
- Support for Ubuntu
- When use mounted sambas shares 
- Reboot device until found mounted destination 

## About 
Restart the Linux device when expected mounted shares were not mounted.

## Installation

### Install dependencies

1. To use the `StateMountedSambaShare` needed, install dotnet. Follow [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

To run from `StateMountedSambaShare` from crontab:
```
@reboot cd /home/user/StateMountedSambaShare && /usr/bin/dotnet StateMountedSambaShare.dll
```

