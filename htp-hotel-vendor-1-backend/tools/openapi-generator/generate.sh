#!/bin/bash
baseFolder="/local/out";
srcFoler="src";
solutionName="Akros.Htp.Exchange";
targetFramework="net5.0";
openapi-generator-cli generate -i http://htp-vendor-hotel2-backend2.azurewebsites.net/v3/api-docs -g csharp-netcore -o $baseFolder --additional-properties=sourceFolder=$srcFoler,useSingleRequestParameter=true,targetFramework=$targetFramework,packageName=$solutionName,optionalAssemblyInfo=false,optionalProjectFile=false --type-mappings=date=DateTime;
rm -rf $baseFolder/$srcFoler/$solutionName/Api;
rm $baseFolder/$srcFoler/$solutionName/$solutionName.csproj;
rm -rf $baseFolder/$srcFoler/$solutionName.Test/Api;
rm $baseFolder/$srcFoler/$solutionName.Test/$solutionName.Test.csproj;
cp -r $baseFolder/$srcFoler /out;
