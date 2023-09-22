# Phanto

## Description

### For non technical users

You can use Phanto to infect a Windows 10 or 11 operating system. This only works if the account you are trying to infect is an Administrator and double clicks Phanto. 

#### Phanto skips the UAC prompt

![UAC Prompt](https://www.lifewire.com/thmb/wjblxy2RyZt9-MlBvpaJIAKdFO8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/uac-windows-10-624bdf97a5fc4002bc6ca895b72ebfd0.png)

### For Developers

#### How Windows UAC works

User Account Control (UAC) is a security feature in Windows that helps prevent unauthorized changes to the computer by prompting the user or administrator for confirmation when attempting to perform certain system-level tasks or install software. It enhances security by reducing the risk of unintentional or malicious system changes.

#### How Windows tokens and Administrative Privileges work

Windows admin users work with two tokens: a standard user token and an elevated admin token. When logged in with a standard user account, the user operates with restricted permissions. When an action requiring administrative privileges is initiated, Windows prompts the user for credentials, and if provided correctly, it temporarily switches to the admin token to perform the task with elevated permissions, helping enhance security by limiting the scope of administrative access.


#### Privilege Escalation (UAC Bypass)

In the absence of administrative privileges, Phanto.exe attempts to elevate its own permissions by attempting to execute itself using the administrator token and gain administrator privileges, all without triggering UAC prompts.

This type of attack is called a UAC bypass.

#### Removing Indicators of Comprimise

Additionally, Phanto also includes functionality to remove indicators of compromise upon completion of its tasks, further covering its tracks and minimizing detection efforts.