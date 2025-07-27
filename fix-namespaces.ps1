# PowerShell script to replace all instances of RichDomain_Poc with DomainDrivenDesign_Poc in .cs files

$rootPath = Resolve-Path "."
$files = Get-ChildItem -Path $rootPath -Recurse -Include *.cs -File

$replaceCount = 0
$fileCount = 0

foreach ($file in $files) {
    $content = Get-Content -Path $file.FullName -Raw
    if ($content -match "RichDomain_Poc") {
        $newContent = $content -replace "RichDomain_Poc", "DomainDrivenDesign_Poc"
        $newContent | Set-Content -Path $file.FullName -NoNewline
        $replaceCount += [regex]::Matches($content, "RichDomain_Poc").Count
        $fileCount++
        Write-Host "Updated: $($file.FullName)"
    }
}

Write-Host "\nUpdate complete!"
Write-Host "Files modified: $fileCount"
Write-Host "Total replacements made: $replaceCount"
