[string[]]
$INCLUDE="bin","obj"

$dirs = Get-ChildItem -Path ./ -Include $INCLUDE -Directory -Recurse -ErrorAction SilentlyContinue 

foreach($d in $dirs){
    Write-Host $d
    remove-item -path $d -Force -Recurse -ErrorAction SilentlyContinue
}