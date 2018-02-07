namespace Xamarin.Forms
{
	public class InputView : View
	{
		public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(InputView), Keyboard.Default,
			coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);


		public static readonly BindableProperty AutoCapitalizationProperty = BindableProperty.Create(nameof(AutoCapitalizationProperty), 
			typeof(AutoCapitalization), typeof(InputView), AutoCapitalization.None);

		internal InputView()
		{
		}

		public Keyboard Keyboard
		{
			get { return (Keyboard)GetValue(KeyboardProperty); }
			set { SetValue(KeyboardProperty, value); }
		}

		public AutoCapitalization AutoCapitalization
		{
			get { return (AutoCapitalization)GetValue(AutoCapitalizationProperty); }
			set { SetValue(AutoCapitalizationProperty, value); }
		}
	}
}