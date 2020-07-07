using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WebApiApp.Models
{
    class EmailValidationBehavior : Behavior<Entry>
    {
        private const string emailRegex = (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
