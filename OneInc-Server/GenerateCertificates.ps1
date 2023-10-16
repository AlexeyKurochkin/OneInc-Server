# Prompt the user for a password
$password = Read-Host -Prompt "Enter the password" -AsSecureString

# Convert the secure string to plain text
$passwordText = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($password))

# Replace the "<PASSWORD_PLACEHOLDER>" with the entered password

dotnet dev-certs https -ep $env:USERPROFILE\AppData\Roaming\ASP.NET\Https\OneInc-Server.pfx -p "$passwordText"
dotnet dev-certs https --trust
dotnet user-secrets set "Kestrel:Certificates:Development:Password" "$passwordText"


Write-Host "Certificates generated successfully."
