namespace ProjectManagerMobile.Controls
{
    public partial class FilledEntryControl : Grid
    {
        public FilledEntryControl()
        {
            InitializeComponent();
            InitializePlaceholder();
        }

        private void InitializePlaceholder()
        {
            if (IsPlaceholderInTopPosition || !string.IsNullOrWhiteSpace(Text))
            {
                PlaceholderLabel.FontSize = PlaceholderFontSize;
                PlaceholderLabel.TranslationY = PlaceholderTranslationY;
            }
            else
            {
                PlaceholderLabel.FontSize = FontSize;
                PlaceholderLabel.TranslationY = 0;
            }
        }

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            propertyName: nameof(Keyboard),
            returnType: typeof(Keyboard),
            declaringType: typeof(FilledEntryControl),
            defaultValue: Keyboard.Default,
            defaultBindingMode: BindingMode.OneWay);

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(FilledEntryControl),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(FilledEntryControl),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(FilledEntryControl),
            defaultValue: 16.0,
            defaultBindingMode: BindingMode.OneWay);

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty PlaceholderFontSizeProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderFontSize),
            returnType: typeof(double),
            declaringType: typeof(FilledEntryControl),
            defaultValue: 14.0,
            defaultBindingMode: BindingMode.OneWay);

        public double PlaceholderFontSize
        {
            get => (double)GetValue(PlaceholderFontSizeProperty);
            set => SetValue(PlaceholderFontSizeProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(FilledEntryControl),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(FilledEntryControl),
            defaultValue: Colors.Black,
            defaultBindingMode: BindingMode.OneWay);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty FocusColorProperty = BindableProperty.Create(
            propertyName: nameof(FocusColor),
            returnType: typeof(Color),
            declaringType: typeof(FilledEntryControl),
            defaultValue: Colors.Black,
            defaultBindingMode: BindingMode.OneWay);

        public Color FocusColor
        {
            get => (Color)GetValue(FocusColorProperty);
            set => SetValue(FocusColorProperty, value);
        }

        public static readonly BindableProperty UnfocusColorProperty = BindableProperty.Create(
            propertyName: nameof(UnfocusColor),
            returnType: typeof(Color),
            declaringType: typeof(FilledEntryControl),
            defaultValue: Colors.Gray,
            defaultBindingMode: BindingMode.OneWay);

        public Color UnfocusColor
        {
            get => (Color)GetValue(UnfocusColorProperty);
            set => SetValue(UnfocusColorProperty, value);
        }

        public static readonly BindableProperty PlaceholderBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(FilledEntryControl),
            defaultValue: Colors.White,
            defaultBindingMode: BindingMode.OneWay);

        public Color PlaceholderBackgroundColor
        {
            get => (Color)GetValue(PlaceholderBackgroundColorProperty);
            set => SetValue(PlaceholderBackgroundColorProperty, value);
        }

        public static readonly BindableProperty PlaceholderTranslationYProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderTranslationY),
            returnType: typeof(double),
            declaringType: typeof(FilledEntryControl),
            defaultValue: -14.0,
            defaultBindingMode: BindingMode.OneWay);

        public double PlaceholderTranslationY
        {
            get => (double)GetValue(PlaceholderTranslationYProperty);
            set => SetValue(PlaceholderTranslationYProperty, value);
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            propertyName: nameof(IsPassword),
            returnType: typeof(bool),
            declaringType: typeof(FilledEntryControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
            propertyName: nameof(IsReadOnly),
            returnType: typeof(bool),
            declaringType: typeof(FilledEntryControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public static readonly BindableProperty IsPlaceholderInTopPositionProperty = BindableProperty.Create(
            propertyName: nameof(IsPlaceholderInTopPosition),
            returnType: typeof(bool),
            declaringType: typeof(FilledEntryControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: OnIsPlaceholderInTopPositionChanged);

        public bool IsPlaceholderInTopPosition
        {
            get => (bool)GetValue(IsPlaceholderInTopPositionProperty);
            set => SetValue(IsPlaceholderInTopPositionProperty, value);
        }

        private static void OnIsPlaceholderInTopPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FilledEntryControl)bindable;
            control.InitializePlaceholder();
        }

        private void EntryField_Focused(object sender, FocusEventArgs e)
        {
            PlaceholderLabel.TextColor = FocusColor;
            PlaceholderLabel.FontSize = PlaceholderFontSize;
            PlaceholderLabel.TranslateTo(0, PlaceholderTranslationY, 80, easing: Easing.Linear);
        }

        private void EntryField_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                PlaceholderLabel.FontSize = PlaceholderFontSize;
                PlaceholderLabel.TranslationY = PlaceholderTranslationY;
            }
            else
            {
                PlaceholderLabel.FontSize = FontSize;
                PlaceholderLabel.TranslateTo(0, 0, 80, easing: Easing.Linear);
            }

            PlaceholderLabel.TextColor = UnfocusColor;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (!IsReadOnly)
            {
                EntryField.Focus();
            }
        }
    }
}
