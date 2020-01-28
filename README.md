# ExemploWorkerAndroidForms

Este exemplo ensina como utilizar o WorkManager para Android com Xamarin.Forms.

O WorkManager nos ajuda a executar tarefas de serviço de segundo plano no Android. Mesmo quando o App não esta aberto. Graças a forma que foi implementado é possivel utilizar o mesmo com Xamarin.Android (Abordagem Classica) e no Xamarin.Forms (Apenas no projeto Android :P ) .

Vamos ver como implementa-lo.

Vamos ao Nuget Instalar o Plugin [Xamarin.Android.Arch.Work.Runtime](https://www.nuget.org/packages/Xamarin.Android.Arch.Work.Runtime/) Apenas no seu projeto Android. Lembre-se do seu projeto Android estar configurado com SDK da versão 9.0 ou seja a API 28.

Existem basicamente duas formas de se utilizar o Worker.

A primeira é a famosa Execução unica , como demonstrado na figura abaixo (Retirada do Artigo do blog da Microsoft) :

Como o nome diz após a execução o Worker é finalizado.

A Segunda forma é a Execução periodica como demonstrado na figura abaixo (Retirada do Artigo do blog da Microsoft) :

Onde toda vez q tivermos sucesso o ciclo sera executado novamente.

Ou seja cabe a você definir o melhor cenario para utilizar o Worker.


Em construção.

Referencia : https://devblogs.microsoft.com/xamarin/getting-started-workmanager/?fbclid=IwAR0ad7HK6KiudW6SMg9taPBdTR8-gIDMyMp5c4DMBS3JH8wHApjjH0evLFg
