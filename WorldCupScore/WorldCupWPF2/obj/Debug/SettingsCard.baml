   M S B A M L   `   `   `  ����F  BWorldCupWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WorldCupWPFWorldCupWPF  5   	       WorldCupWPF.SettingsCard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WorldCupWPF     5   	     � Title$  Soccer Board Settings��5      $	��220��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      � 
������$��	0,0,0,-16q�6#    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lblSoccerBoardSettings��5      $��Soccer Board Settings��6.   $��Center=�6N   $��0,10,0,5q�6k   $��16(�6}   � 5   
   $��1��6   
��� � �$��10q�6/   $��Center=�6;    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��10q�6)   .+�5      �� -   5        $��lblLanguage��5      $��Language��6+   $
��Bold"�6>   	� 5      -   5         	�Name$ 	rbEnglish��5      $��English��61   6E   	� 5      -   5        $ 
rbCroatian��5      $��Croatian��62   6G   5      �� 5      $��1��6   $��10q�6)   .+�5       �� -   5        $��lblChampionship��5       $��Championship��6/   $
��Bold"�6F   6Z   	� 5!      -   5        $��rbMen��5!      $	��Men��6+   6;   	� 5"      -   5        $��rbWomen��5"      $��Women��6-   6?   �� 5#      -   5        $��	cbOffline��5#      $��Offline mode��6,   6E   5$      �� 5&      $��2��6   $��10q�6)   .+�5'      �� -	   5        $��lblResolution��5'      $��
Resolution��6-   $
��Bold"�6B   6V   	� 5(      -
   5        $��rb800��5(      $��	800x600px��6+   6A   	� 5)      -   5        $��rb1024��5)      $��
1024x768px��6,   6C   	� 5*      -   5        $��rbFullScreen��5*      $��Full screen��62   6J   5,      5/      �� 51   
   -   5        $��btnOK��51      $��2��6   $��OK��6,   $	��100��69   $��20��6E   $
��Left=�6Q   $��50,0,0,0q�6l   6�   �� 52   
   -   5        $��	btnCancel��52      $��2��6#   $��Cancel��60   $	��100��6A   $��20��6M   $��Right=�6Y   $��0,0,50,0q�6u   6�   54      56      