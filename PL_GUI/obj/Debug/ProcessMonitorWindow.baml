   M S B A M L   `   `   `  ����A  =PL_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PL_GUIPL_GUI  5   	   !    PL_GUI.ProcessMonitorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PL_GUI     5   	     � Title$  ProcessMonitor��5   	   $	��600��6    $	��600��6-   .��5	      � ��5
   
   �� 5       �� ImageSource$ Image/background.png��6   .+�5   
   �� -   5         ��Name$ Back_To_Main_Menu��5      $��425,1,0.333,522.667q�6-    J� RenderTransformOrigin$ 0.5,0.5&�6w   $��	Main Menu��6�   
�������$��Broadway)�6�   $��18(�6�   ��5      �� 5       �� Color$ 	#FF707070��6"    �� Opacity$ 0Q�64   ��5      �� 5      $ 	#FFDDDDDD��6"   $ 0Q�64   5      �� 5   
   $��0,10,357.333,498.667q�6   
������ 
���������6I   ��  �� Path$ totalCPU�.��6|   5      �� 5   
   $��241,10,115.333,498.667q�6   
������ 
���������6K   �� $ totalMemory�.��6�   5      �� 5   
   -   5        $ End_Task��5      $��224,459,201.333,64.667q�6$   $ 0.5,0.5&�6Z   $��End Task��6z   
�������$��Broadway)�6�   $��18(�6�   ��5      �� 5      $ 	#FF707070��6"   $ 0Q�64   ��5      �� 5       $ 	#FFDDDDDD��6"   $ 0Q�64   5"      �� 5#   
   -   5        $��Process_List��5#   1   $��60,72,45.333,116.667q�6   ��6E   �� *pro+ �� View 5$      �� 5%      .P�5&      ��  �� Width$ 45��6&   	 �� CellTemplate	 5'      �� 5(      .R�5)   "   �� -   5        
 d� 	IsChecked
 5)   +   �� *	process+ �� Mode$ TwoWay=�6q   5*      ��5,      �� 5-      -   5        
 � Tag$
 Name��5-   3   .��6T   Select5.      50      �� 51      $	 200��6&    �� DisplayMemberBinding 62   �� *pName+��52      �� 53      -   5        $
 Name��53   3   .��6T   Name54      56      �� 57      $ 70��6&    61   �� *cpu+��58      �� 59      -   5        $	��cpu��59   3   $	 CPU��6?   .��6_   	CPU (%)5:      5<      �� 5=      $	 150��6&    62   �� *memory+��5>      �� 5?      -   5        $ Memory��5?   3   .��6V   Memory Usage (MB)5@      5B      5C      5F      5G      5H      