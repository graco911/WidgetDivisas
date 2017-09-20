using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using WidgetDivisas.DataAccess;
using Android.Graphics;
using Square.Picasso;
using System.Threading.Tasks;
using WidgetDivisas.Models;
using Android.Appwidget;
using Java.Lang.Annotation;

namespace WidgetDivisas.Services
{
    [Service]
    public class ExchangeService : Service
    {
        DivisasData divisa;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override async void OnStart(Intent intent, int startId)
        {
            var updateviews = await WidgetUpdate(this);

            var me = new ComponentName(this, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            AppWidgetManager manager = AppWidgetManager.GetInstance(this);
            manager.UpdateAppWidget(me, updateviews);

        }
        public async Task<RemoteViews> WidgetUpdate(Context context)
        {
            DivisasAccess request = new DivisasAccess();
            divisa = await request.GetDivisasAsync();
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.Widget);
            
            if (divisa != null)
            {
                widgetView.SetTextViewText(Resource.Id.textViewCountryReferent, divisa.@base);
                widgetView.SetTextViewText(Resource.Id.textViewCountryEquivalent, "MXN");
                widgetView.SetTextViewText(Resource.Id.textViewRatioReference, "1");
                widgetView.SetTextViewText(Resource.Id.textViewRatioEquivalent, divisa.rates.MXN.ToString());

                widgetView.SetImageViewResource(Resource.Id.imageViewEquivalent, Resource.Drawable.mxn);
                widgetView.SetImageViewResource(Resource.Id.imageViewReferent, Resource.Drawable.usd);
            }

            return widgetView;
        }
    }
}