   M S B A M L   `   `   `  ����A  =PL_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PL_GUIPL_GUI  5   	       PL_GUI.AddEmailForAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PL_GUI     5   	     � Title$  AddEmailForAdmin��5   	   $	��300��6"   $	��300��6/   ��5	      �� 5
   
    �� ImageSource$ image/background.png��6   .��5      � .+�5   
   ]� $��0,0,0.2,253.8q�6   .+�5      �� -   5        $
��Back��5      $��10(�6!   
�������$��Broadway)�6V   $
��Back��6m    J� RenderTransformOrigin$ 0.455,0.684&�6|   $��25,0,223.2,0.2q�6�   $��19��6�   $��61��6�   ��5      �� 5       �� Color$ 	#FF707070��6&    �� Opacity$ 0Q�68   ��5      �� 5      $ 	#FFDDDDDD��6&   $ 0Q�68   5      �� 5      -   5         ��Name$ MainMenu��5      $��10(�6'   
�������$��Broadway)�6`   $��	Main Menu��6v   $��	0,0,0,0.2q�6�   $��38��6�   $ -0.54,0.411&�6�   ��5      �� 5      $ 	#FF707070��6&   $ 0Q�68   ��5      �� 5      $ 	#FFDDDDDD��6&   $ 0Q�68   5      5       �� 5!   
   $
��Left=�6   $	��273��60   $	��Top=�6=   $	��295��6U   $��0,0,0,0q�6a   .+�5"      �� 
�������$��Broadway)�6'   $��23��6=   $��12(�6I   $��0,0,0,0q�6W   $��Please enter you E-mail:��6h   $ 0.436,-1.215&�6�   �� 5#      -   5         ��Name$ EmailBox��5#      $��26��6(    �� TextWrapping$
 Wrap=�64   $�� ��6H   $��	52,0,52,0q�6P   $��12(�6c   �� 5$      -   5         ��Name$ wrongEmailText��5$      $
��Wrap=�60   $��Email is not valid��6D   $��52,0,52.2,0q�6^   $��10��6s   $��8(�6   
���  ��6�   �� 5%      -   5        	 ��Name$	 
getUpdates��5%      $)��#I would like to get E-mail allerts.��6+   $��10,10,0.2,0q�6Y   
�������$��8(�6�   5&   3   �� 5'      -   5        
 ��Name$
 	ifChecked��5'      $	��137��6,   $��10,10,00.2,0q�69   $y�Visible=�6O   .+�5(      �� 
�������$��Broadway)�6+   $��22��6A   $��12(�6M   $��0,0,0,0q�6[   $/��)Please choose your preffered subjects you��6l   $ 0.436,-1.215&�6�   �� 5)      
�������$��Broadway)�6+   $��22��6A   $��12(�6M   $��
0,0,-0.2,0q�6[   $1��+would like to recieve an E-mail allert for:��6o   $ 0.436,-1.215&�6�   �� 5*      -   5        $	 logOn��5*       d� 	IsChecked$ falseY�6*   $��User log on��6<   
�������6j   �� 5+      -   5        $	 logOff��5+      $ falseY�6+   $��User log off��6=   
�������6l   �� 5,      -	   5        $	 changePassword��5,      $ falseY�63   $��User changed password��6E   
�������6�   �� 5-      -
   5        $	 
encryption��5-      $ falseY�6/   $#��User accessed encryption tool��6A   
�������6�   �� 5.      -   5        $	 dataLeakage��5.      $ falseY�60   $%��User accessed data leakage tool��6B   
�������6�   �� 5/      -   5        $	 processMonitor��5/      $ falseY�63   $#��User accessed process monitor��6E   
�������6�   50      �� 51      -   5        $ update��51      $��Update��6%   $��	95,5,95,0q�6K   53      55      56      