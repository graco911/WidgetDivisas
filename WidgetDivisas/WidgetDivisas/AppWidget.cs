using Android.App;
using Android.Content;
using Android.Appwidget;
using WidgetDivisas.Services;

namespace WidgetDivisas
{
    [BroadcastReceiver(Label = "Divisas Widget")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/appwidgetprovider")]
    public class AppWidget : AppWidgetProvider
    {
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            context.StartService(new Intent(context, typeof(ExchangeService)));
        }
    }
}