Get-NetAdapter -Physical | ForEach-Object {

    $Properties = @{
        Name        = $_.Name
        MacAddress  = $_.MacAddress
        AdminStatus = $_.AdminStatus
    }

    $Object = New-Object psobject -Property $Properties

    $Object
}

Pause