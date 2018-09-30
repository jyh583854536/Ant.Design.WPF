﻿using System.Windows;
using System.Windows.Input;
using ButtonBase = System.Windows.Controls.Button;

namespace Antd.Controls
{
    public class Button : ButtonBase
    {
        #region Properties

        public static readonly DependencyProperty GhostProperty = 
            DependencyProperty.Register("Ghost", typeof(bool), typeof(Button), new PropertyMetadata(false));

        /// <summary>
        ///  Gets/sets ghost property to make the button background transparent
        /// </summary>
        public bool Ghost
        {
            get { return (bool)GetValue(GhostProperty); }
            set { SetValue(GhostProperty, value); }
        }

        public static readonly DependencyProperty HrefProperty =
            DependencyProperty.Register("Href", typeof(string), typeof(Button), new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets click the button to jump to the url
        /// </summary>
        public string Href
        {
            get { return (string)GetValue(HrefProperty); }
            set { SetValue(HrefProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(Button), new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets the icon type of the button
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty LoadingProperty =
            DependencyProperty.Register("Loading", typeof(bool), typeof(Button), new PropertyMetadata(false, OnLoadingChanged));

        /// <summary>
        /// Gets/sets the loading state of the button
        /// </summary>
        public bool Loading
        {
            get { return (bool)GetValue(LoadingProperty); }
            set { SetValue(LoadingProperty, value); }
        }

        private static void OnLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VisualStateManager.GoToState(d as Button, (bool)e.NewValue ? "Loaded" : "Unloaded", true);
        }

        public static readonly DependencyProperty CircularProperty =
            DependencyProperty.Register("Circular", typeof(bool), typeof(Button), new PropertyMetadata(false));

        /// <summary>
        /// Gets/sets the shape of the button to be circular. Used to replace the shape attribute in ant design
        /// </summary>
        public bool Circular
        {
            get { return (bool)GetValue(CircularProperty); }
            set { SetValue(CircularProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty = 
            DependencyProperty.Register("Type", typeof(ButtonType?), typeof(Button), new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets button type
        /// </summary>
        public ButtonType? Type
        {
            get { return (ButtonType?)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        #endregion

        #region Constructors

        static Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(typeof(Button)));
        }

        #endregion

        #region Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (Loading) return;
            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            if (Loading) return;
            base.OnMouseEnter(e);
        }

        protected override void OnClick()
        {
            if (Loading) return;
            base.OnClick();
        }

        #endregion
    }

    public enum ButtonType
    {
        Primary, Dashed, Danger
    }
}