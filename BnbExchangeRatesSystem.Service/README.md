# BnbExchangeRateClient
Fetch data from BNB for dayly exchane rates

## Publish the app
dotnet publish --output "E:\Temp\BnbExchangeRates"

## Create the Windows service
sc.exe create "Bnb ExchangeRates Service" binpath="E:\Temp\BnbExchangeRates\BnbExchangeRatesSystem.Service.exe"

## Configure the Windows service
sc.exe failure "Bnb ExchangeRates Service" reset=0 actions=restart/60000/restart/60000/run/1000

## Start the Windows service
sc.exe start "Bnb ExchangeRates Service"