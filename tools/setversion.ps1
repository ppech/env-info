param([String]$version)

if([String]::IsNullOrWhitespace($version)) {
	$version = Read-Host "Version"
}

$packages = @(
	[pscustomobject]@{ Project = "EnvInfo.Core" },
	[pscustomobject]@{ Project = "EnvInfo.DotVVM" },
	[pscustomobject]@{ Project = "EnvInfo.Mvc" }
)

foreach ($package in $packages) {
    $filePath = "$PSScriptRoot/../src/$($package.Project)/$($package.Project).csproj"
    $file = [System.IO.File]::ReadAllText($filePath, [System.Text.Encoding]::UTF8)
	$file = [System.Text.RegularExpressions.Regex]::Replace($file, "\<PackageVersion\>([^<]+)\</PackageVersion\>", "<PackageVersion>" + $version + "</PackageVersion>")
	[System.IO.File]::WriteAllText($filePath, $file, [System.Text.Encoding]::UTF8)
}