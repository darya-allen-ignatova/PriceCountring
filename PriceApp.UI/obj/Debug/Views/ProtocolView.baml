   M S B A M L   `   `   `  ����F  BPriceApp.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PriceApp.UI.ViewsPriceApp.UI.Views  5   	   ?$clr-namespace:PriceApp.UI.ConvertersPriceApp.UI.Converters  5   	   $    PriceApp.UI.Views.ProtocolView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PriceApp.UI.Views     5   	   2k$clr-namespace:PriceApp.UI.Converters     5   	     � Title$  ProtocolView��5	   	   $	��600��6   $
��1100��6+   $	��600��68   $
��1100��6H   
�������$
��1100��6k   ��5
      �� 5   
    �� ImageSource$+ %/PriceApp.UI;component/Images/bg.jpeg��6   .��5      � .+�5   
   o� $��25��6   $	��Top=�6   
�������
���������5      �� 5      $+ %/PriceApp.UI;component/Images/bg.jpeg��6   .@�5      m� -   5        $��ConfigurationCommand��5   @      Configuration#���   6   $��16(�6\   
�������6j   5      � 5   
   $��10,50,30,30q�6   ��5      �� 5       � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $
��1.5* �6    �� 5      �� 5       � ColumnDefinitions 5       �� 5!      $��1* �6#   �� 5"      �� 5#      $��1* �6#   .+�5%      �� $��0��6   $��0��6%     Provider#���  65   $��20(�6W   �� 5&      $��1��6   $��0��6%    	 Price#���  65   $��20(�6T   � 5'      $��2��6   $��0��6    $��2��60    � 	Resources 5(      1   +PriceApp.UI.Converters.EnumBooleanConverter  enumBooleanConverter��%   &	         5)      6-   5*       5+      �� 5,      �� 5-       5/      �� 50      �� 51      �� 52      �� 53      .+�55      �� $��0��6   $��0��6)   $��4��69     PaymentType#���  6M   $��20(�6r   	� 56       	� 	GroupName$" SelectedProvider_PaymentType��6   $��1��6H   $��0��6U   $��14(�6e   
�������$	��5,0q�6�    d� 	IsChecked 57      �� *SelectedProvider_PaymentType+ �� Mode$ TwoWay=� �� 	Converter# [ 	 �� ConverterParameter$	 FullPrepayment����58      �� 59      $
��Wrap=�6$     FullPrepayment#���  68   5;      	� 5<      $" SelectedProvider_PaymentType��6   $��1��6G   $��1��6T   $��14(�6d   
�������$	��5,0q�6�    5=      �� *SelectedProvider_PaymentType+$ TwoWay=�# [ $	 FullPostpayment����5>      �� 5?      $
��Wrap=�6$     FullPostpayment#���  68   5A      	� 5B      $" SelectedProvider_PaymentType��6   $��1��6G   $��2��6T   $��14(�6e   
�������$	��5,0q�6�    5C      �� *SelectedProvider_PaymentType+$ TwoWay=�# [ $	 PartlyPrepayment����5D      �� 5E      $
��Wrap=�6$     PartlyPrepayment#���  68   5G      	� 5H      $" SelectedProvider_PaymentType��6   $��1��6G   $��3��6T   $��14(�6d   
�������$	��5,0q�6�    5I      �� *SelectedProvider_PaymentType+$ TwoWay=�# [ $	 Mixed����5J      �� 5K      $
��Wrap=�6$    	 Mixed#���  68   5M      5N      �� 5O      -   5        $��SelectedProvider_Name��5O      $��1��64   $��27��6D   
 �� TextAlignment$
 Right=�6P   $
��18px(�6f   $��	10,10,0,0q�5P       �� TextWrapping$
 Wrap=�6)   $	��Top=�6>   �� 5Q      -   5        $��SelectedProvider_Price��5Q      $��1��65   $��28��6E   $
 Right=�6Q   $
��18px(�6g   $��	10,10,0,0q�5R      $
 Wrap=�6)   $	��Top=�6>   $��1��6V   � 5S      $��3��6   $��0��6    $��2��60   $��2��6D    5T      �� 5U      �� 5V      �� 5W       5Y      �� 5Z      �� 5[      �� 5\      �� 5]      .+�5_      �� $��0��6   $��0��6)   ��6:   �� *FirstDayAmount+�� 5`      -   5        $%��SelectedProvider_FirstDayAmount��5`      $��1��6A   $��0��6Q   $��25��5a      $
 Right=�6&   $
��18px(�6<   �� 5b      $��1��6   $��0��6)   ��6:   �� *SecondDayAmount+�� 5c      -   5        $&�� SelectedProvider_SecondDayAmount��5c      $��1��6B   $��25��6R   $��1��5d      $
 Right=�6'   $
��18px(�6=   �� 5f      $��0��6   $��2��6)   ��6:   �� *FirstPercentage+�� 5g      -   5        $$��SelectedProvider_FirstPercenge��5g      $��3��6@   $��25��6P   $��0��5h      $
 Right=�6'   $
��18px(�6=   �� 5i      $��1��6   $��2��6)   ��6:   �� *FirstDayAmount+�� 5j      -   5        $%��SelectedProvider_SecondPercenge��5j      $��3��6A   $��25��6Q   $��1��5k      $
 Right=�6'   $
��18px(�6=   �� 5m      -   5        $��
NewCommand��5m      $��0��6+   $��4��6;    	 
New_button#��� 	 6H   $��0,0,5,0q�6o   $��16(�5n      $��30��6'   $��Bottom=�63   
����������	#FF043E5F6a   �� 5o      -	   5        $��SaveCommand��5o      $��1��6,   $��4��6<    
 Save_button#��� 
 6I   $��16(�5p      $��30��6'   $��Bottom=�63   
����������	#FF043E5F6a   �� 5q      -
   5        $��DeleteCommand��5q      $��3��6.   $��4��6>     Delete_button#���  6K   $��16(�5r      $��30��6'   $��Bottom=�63   
����������	#FF043D5D6a   5s      �� 5u      -   5         ��Name$ 	Providers��5v      $��2��5u      $��0��6'   $��6��64   $��20,0,0,0q�6E   $
��Auto=�5v   *   $��16(�5w       �� View 5x      �� 5y      .P�5z      ��  	 Place#���  6%    �� Width$
 55px��6r    �� DisplayMemberBinding 6F   ��  �� Path$ Place�6r   �� 5{        ProviderName#���  6)   $ 210px��6|    6Q   �� $
 Name�6|   �� 5|        ResultPriceAmount#���  6)   $
 60px��6�    6V   �� $ ResultPrice�6�   5}      5      5�      5�      5�      