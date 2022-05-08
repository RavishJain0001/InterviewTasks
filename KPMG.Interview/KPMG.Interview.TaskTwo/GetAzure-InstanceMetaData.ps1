
<#
    This script lists the instance metadata in an Azure VM. It takes one input paramater to specify
    instance data key name. For example if we want the azEnvironment property, pass input as compute.azEnvironment
#>
param (
    # name of the output image
    [string]$dataQuery = ''
)


$Query = $dataQuery

$AllData = Invoke-RestMethod -Headers @{"Metadata"="true"} -Method GET -Uri "http://169.254.169.254/metadata/instance?api-version=2021-02-01" | ConvertTo-Json -Depth 64

if($Query -eq '')
{
    $AllData
}
else 
{
    $AllDataObj = ConvertFrom-Json $AllData

    $Properties = $Query.split('.')
    $Properties | ForEach-Object {
        if ($_ -ne $Properties[-1]) {
            #iterate through properties
            $AllDataObj = $AllDataObj.$_
        } else {
            #Output last value
            $AllDataObj.$_ | ConvertTo-Json -Depth 64
        }
    }
}