   M S B A M L   `   `   `  ����U  QRestaurantApp.SunumKatmani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:RestaurantApp.SunumKatmani.Views.KullanıcıViews1RestaurantApp.SunumKatmani.Views.KullanıcıViews  5   	   A    ;RestaurantApp.SunumKatmani.Views.KullanıcıViews.LoginPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:RestaurantApp.SunumKatmani.Views.KullanıcıViews     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	LoginPage��5   	    � SizeToContent$ Height=�5	   	   $	��400��5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��40 �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5      �� $��Lütfen Giriş Yapınız��6   $��Center=�5      $��Center=�5      $��	0 50 0 10q�5        $  MaterialDesignHeadline4TextBlock#��[ 5!      '  !MaterialDesignThemes.Wpf.PackIcon  5"         Kind$ Shield=�6&   $��Center=�5#   &   $	��120��5$   &   $	��120��5%   &   $��0 0 0 40q�5&   &   5'      � 5)   
   $��1��6    � ColumnDefinitions 5*      �� 5+      $
��Auto �6#   �� 5,      $��* �6#   .+�5.        $
 Mail=�5/   &   $��24��50   &   $��24��51   &   $��0 0 10 0q�52   &   $��Center=�53   &   ��54      �� 55       �� 
TargetType"  6    �� Triggers 56      �� 57      	 �� Binding	 6*   �� *	IsFocused+
 �� ElementName$
 txtKullanıcıAdı�� �� Value True6e   .a�58   "   ��  �� Property � ��  PrimaryHueMidBrush �� Value# [ 6?   59      5;      5=      �� 5?      -   5         ��Name$ txtKullanıcıAdı��5?      $��1��5@      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Kullanıcı Adı��5A      .��6E   5B      5C      � 5E   
   $��2��6   $
��10 3q�5F       5G      �� 5H      $
��Auto �6#   �� 5I      $��* �6#   .+�5K        $	 Key=�5L   &   $��24��5M   &   $��24��5N   &   $��0 0 10 0q�5O   &   $��Center=�5P   &   ��5Q      �� 5R      "  6    5S      �� 5T      	 6*   �� *	IsFocused+$
 kullanıcı.�� True6`   .a�5U   "   ��  � ��# [ 6?   5V      5X      5Z      G� 5\      -   5         G�Name$ 	txtParola��5\      $��1��5]       ) %MaterialDesignFloatingHintPasswordBox#��[ 5^      $ Parola��5_      5`      �� 5b   
   -   5         ��Name$ lblError��5b      $�� ��6'   
���  ��$��Center=�5d      $��Center=�5e      $��3��5f      �� 5h   
   -   5        $��Giriş��5h      $��4��5i      5j      5l      5m      