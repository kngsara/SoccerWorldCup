   M S B A M L   `   `   `  ����F  BWorldCupWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WorldCupWPFWorldCupWPF  5   	   $    WorldCupWPF.ScoreOverviewBoard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WorldCupWPF     5   	     � Title$!  Soccer Score Overview Board��5      $	��350��6%   $	��300��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � 
������ � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lblOverview��5      $��Overview of Soccer Scores��6#   $��Center=�6G   $��0,10,0,5q�6d   $��16(�6v   � 5   
   $��1��6   
��� � �$��10q�6/    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��10q�6)   .+�5      �� -   5         ��Name$ lblCountryCode��5      $��0��60   $��0��6@   $
��Bold"�6M   $��15(�6_   $
��left=�6m   .��6�   Country code6�   �� 5      -   5        $ lblWins��5      $��0��6)   $��0��69   $
��Bold"�6F   $��15(�6X   $
��left=�6f   .��6�   	Team wins6�   �� 5      -   5        $ 	lblLosses��5      $��0��6+   $��0��6;   $
��Bold"�6H   $��15(�6Z   $
��Left=�6h   .��6�   Losses6�   �� 5      -   5        $ lblDraws��5      $��0��6*   $��0��6:   $
��Bold"�6G   $��15(�6Y   $
��Left=�6g   .��6�   Draws6�   �� 5      -   5        $ lblGamesPlayed��5      $��0��60   $��0��6@   $
��Bold"�6M   $��15(�6_   $
��Left=�6m   .��6�   Games played6�   �� 5      -   5        $ 	lblPoints��5      $��0��6+   $��0��6;   $
��Bold"�6H   $��15(�6Z   $
��Left=�6h   .��6�   Points6�   �� 5      -   5        $ lblGoalsFor��5      $��0��6-   $��0��6=   $
��Bold"�6J   $��15(�6\   $
��Left=�6j   .��6�   	Goals for6�   �� 5      -	   5        $ lblGoalsAgainst��5      $��0��61   $��0��6A   $
��Bold"�6N   $��15(�6`   $
��Left=�6n   .��6�   Goals against6�   5       �� 5"      $��1��6   $��10q�6)   .+�5#      �� -
   5        $ lblCountryCodeScore��5#      $��1��65   $��1��6E   $
��left=�6R   $��30��6m   $��16��6y   6�   �� 5$      -   5        $ lblTeamWinsScore��5$      $��1��62   $��1��6B   $
��left=�6O   $��30��6j   .��6v   06y   �� 5%      -   5        $ lblLossesScore��5%      $��1��60   $��1��6@   $
��left=�6M   $��30��6i   .��6u   06x   �� 5&      -   5        $ lblDrawsScore��5&      $��1��6/   $��1��6?   $
��left=�6L   $��30��6h   .��6t   06w   �� 5'      -   5        $ lblGamesPlayedScore��5'      $��1��65   $��1��6E   $
��left=�6R   $��30��6n   .��6z   06}   �� 5(      -   5        $ lblPointsScore��5(      $��1��60   $��1��6@   $
��left=�6M   $��30��6i   .��6u   06x   �� 5)      -   5        $ lblGoalsForScore��5)      $��1��62   $��1��6B   $
��left=�6O   $��30��6j   .��6v   06y   �� 5*      -   5        $ lblGoalsAgainstScore��5*      $��1��66   $��1��6F   $
��left=�6S   $��30��6n   .��6z   06}   5,      5-      5.      5/      