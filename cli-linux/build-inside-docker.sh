#!/bin/sh
set -e
echo ""
#echo "Docker Build CLI for Sample"

mainFolderPath=$(pwd)
outFolderPath=/app
solutionFile=${mainFolderPath}/Sample.sln

verbosity=minimal
configuration=Release

if ! [ -z "$1" ]
then
  verbosity=$1
fi

if ! [ -z "$2" ]
then
  configuration=$2
fi

echo ""

dotnet restore ${solutionFile} -v ${verbosity}
dotnet build ${solutionFile} -c ${configuration} -o ${outFolderPath} -v ${verbosity} --no-restore
dotnet publish -c ${configuration} -o ${outFolderPath} -v ${verbosity} --no-restore
echo ""
