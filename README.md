# ExemploWorkerAndroidForms

Este exemplo ensina como utilizar o WorkManager para Android com Xamarin.Forms.

O WorkManager nos ajuda a executar tarefas de serviço de segundo plano no Android. Mesmo quando o App não esta aberto. Graças a forma que foi implementado é possivel utilizar o mesmo com Xamarin.Android (Abordagem Classica) e no Xamarin.Forms (Apenas no projeto Android :P ) .

Vamos ver como implementa-lo.

Vamos ao Nuget Instalar o Plugin [Xamarin.Android.Arch.Work.Runtime](https://www.nuget.org/packages/Xamarin.Android.Arch.Work.Runtime/) Apenas no seu projeto Android. Lembre-se do seu projeto Android estar configurado com SDK da versão 9.0 ou seja a API 28.

Existem basicamente duas formas de se utilizar o Worker.

A primeira é a famosa Execução unica , como demonstrado na figura abaixo (Retirada do Artigo do blog da Microsoft) :

<img src="https://github.com/TBertuzzi/ExemploWorkerAndroidForms/blob/master/Resources/ExecucaoUnica.png?raw=true" alt="Smiley face" height="500" width="700">

Como o nome diz após a execução o Worker é finalizado.

A Segunda forma é a Execução periodica como demonstrado na figura abaixo (Retirada do Artigo do blog da Microsoft) :

<img src="https://github.com/TBertuzzi/ExemploWorkerAndroidForms/blob/master/Resources/execucaoPeriodica.png?raw=true" alt="Smiley face" height="500" width="700">

Onde toda vez q tivermos sucesso o ciclo sera executado novamente.

Ou seja cabe a você definir o melhor cenario para utilizar o Worker.

Para utilizar o nosso Worker temos que criar uma classe herdando de "Worker" e fazer Override do método DoWork :

```c#

 public class MeuWorker : Worker
    {
        public MeuWorker(Context context, WorkerParameters workerParams)
          : base(context, workerParams)
        {
        }

        public override Result DoWork()
        {
            try
            {
                Log.Info("Teste", $"{DateTime.Now} Iniciando Serviço de BackGround ");

                Log.Info("Local", $"{DateTime.Now} Acessando para Testar");

                return new Result.Retry();
            }
            catch(Exception ex)
            {
                return new Result.Failure();
            }
        }
    }

```

Apenas para exemplificar eu coloquei um Log para demonstrar quando o Worker é executado. Mas e esse Result?

Existem 3 tipos de resultado :

* Finalizado com sucesso -> Result.Success()
* Algum erro ocorreu -> Result.Failure()
* Deve executar novamente -> Result.Retry()

A utilização deles depende de como você quer utilizar o Worker. O Retry no caso é para manter a execução periodica. Ja o Sucesso e a falha podem ser utilizados em uma tratativa de erro. Caso queira executar apenas uma vez , você pode retornar apenas o Sucess ao inves do Retry.

Para finalizar vamos chamar o Worker na nossa classe MainActivity.cs :

```c#

 [Activity(Label = "ExemploWorkerAndroidForms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            LoadApplication(new App());

            //Processo do Worker Executa a cada 5 Segundos
            var processo = PeriodicWorkRequest.Builder.From<MeuWorker>(TimeSpan.FromSeconds(5)).Build();
            WorkManager.Instance.Enqueue(processo);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum]  Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

```

O PeriodicWorkRequest chamara nosso Worker e fara a execução. No meu caso deixei para ele fazer a cada 5 segundos, o tempo vai depender da sua necessidade.

Pronto! Assim que executar , tera o Worker rodando :)

Caso fique a duvida este repositorio tem um exemplo da implementação completa. E claro, tambem o artigo original que me motivou a fazer esse exemplo e você pode conferir [Clicando Aqui](https://devblogs.microsoft.com/xamarin/getting-started-workmanager/?fbclid=IwAR0ad7HK6KiudW6SMg9taPBdTR8-gIDMyMp5c4DMBS3JH8wHApjjH0evLFg)

Quer ver outros artigos sobre Xamarin ? [Clique aqui](https://github.com/TBertuzzi/XXamarin)

Espero ter ajudado!

Aquele abraço!

