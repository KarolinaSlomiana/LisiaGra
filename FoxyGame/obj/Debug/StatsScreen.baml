   M S B A M L   `   `   `  ����C  ?FoxyGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FoxyGameFoxyGame  5   	       FoxyGame.StatsScreen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:FoxyGame     5   	   $	��450��5   	   $	��800��6   .��5	      � .+�5
   
   �� -   5          ��Name$  FoxImage��5
      $
��Left=�6"   $	��280��6=   $��
445,40,0,0q�6J   $	��Top=�6^   $	��215��6v   �� 5   
   -   5         ��Name$ StrenghtLabel��5      $��Siła��6'   $
��Left=�66   $��
78,105,0,0q�6Q   $	��Top=�6e   $��30��6}   $	��140��6�   �� 5   
   -   5        $ 	NameLabel��5      $0��*Witaj na szkoleniu Lisich Agentów, imię!��6#   $
��Left=�6V   $��	50,26,0,0q�6q   $	��Top=�6�   $��39��6�   $	��323��6�   $��16(�6�   �� 5   
   -   5        $ StaminaLabel��5      $��Wytrzymałość��6&   $
��Left=�6=   $��
78,155,0,0q�6X   $	��Top=�6l   $��30��6�   $	��140��6�   �� 5   
   -   5        $ AgilityLabel��5      $��
Zwinność��6&   $
��Left=�69   $��
78,205,0,0q�6T   $	��Top=�6h   $��30��6�   $	��140��6�   �� 5   
   -   5        $ 	LuckLabel��5      $��Szczęście��6#   $
��Left=�67   $��
78,255,0,0q�6R   $	��Top=�6f   $��30��6~   $	��140��6�   �� 5   
   -   5        $ StrenghtValueLabel��5      $�� ��6,   $
��Left=�67   $��288,105,0,0q�6R   $	��Top=�6g   $��39��6   �� 5   
   -   5         ��Name$ StrenghtMinusButton��5      $��-��6.   $
��Left=�6:   $��258,105,0,0q�6U   $	��Top=�6j   $��25��6�   $��25��6�   6�   �� 5   
   -	   5        $ StrenghtPlusButton��5      $��+��6-   $
��Left=�69   $��332,105,0,0q�6T   $	��Top=�6i   $��25��6�   $��25��6�   6�   �� 5   
   -
   5        $ LuckPlusButton��5      $��+��6)   $
��Left=�65   $��332,255,0,0q�6P   $	��Top=�6e   $��25��6}   $��25��6�   6�   �� 5   
   -   5        $ AgilityPlusButton��5      $��+��6,   $
��Left=�68   $��332,205,0,0q�6S   $	��Top=�6h   $��25��6�   $��25��6�   6�   �� 5   
   -   5        $ StaminaPlusButton��5      $��+��6,   $
��Left=�68   $��332,156,0,0q�6S   $	��Top=�6h   $��25��6�   $��25��6�   6�   �� 5   
   -   5        $ LuckMinusButton��5      $��-��6*   $
��Left=�66   $��258,255,0,0q�6Q   $	��Top=�6f   $��25��6~   $��25��6�   6�   �� 5   
   -   5        $ AgilityMinusButton��5      $��-��6-   $
��Left=�69   $��258,205,0,0q�6T   $	��Top=�6i   $��25��6�   $��25��6�   6�   �� 5   
   -   5        $ StaminaMinusButton��5      $��-��6-   $
��Left=�69   $��258,155,0,0q�6T   $	��Top=�6i   $��25��6�   $��25��6�   6�   �� 5   
   -   5        $ LuckValueLabel��5      $�� ��6(   $
��Left=�63   $��288,256,0,0q�6N   $	��Top=�6c   $��39��6{   �� 5   
   -   5        $ AgilityValueLabel��5      $�� ��6+   $
��Left=�66   $��288,205,0,0q�6Q   $	��Top=�6f   $��39��6~   �� 5   
   -   5        $ StaminaValueLabel��5      $�� ��6+   $
��Left=�66   $��288,155,0,0q�6Q   $	��Top=�6f   $��39��6~   �� 5   
   -   5        $ AvailablePointsLabel��5      $�� ��6.   $
��Left=�69   $��137,302,0,0q�6T   $	��Top=�6i   $��50��6�   $	��100��6�   �� 5   
   -   5        $ 
NextButton��5      $��Do świata mafii��6%   $
��Left=�6?   $��679,311,0,0q�6Z   $	��Top=�6o   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $ 	TypeLabel��5      $�� ��6#   $
��Left=�6.   $��469,327,0,0q�6I   $	��Top=�6^   $	��175��6v   $��30��6�   �� 5   
   -   5        $ 
StatsLabel��5      $#��Wybierz swoje umiejętności:��6$   $
��Left=�6J   $��	78,65,0,0q�6e   $	��Top=�6x   $	��197��6�   5       5!      