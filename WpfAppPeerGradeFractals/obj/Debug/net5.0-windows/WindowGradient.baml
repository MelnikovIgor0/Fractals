   M S B A M L   `   `   `  ����R  NWpfAppPeerGradeFractals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfAppPeerGradeFractalsWpfAppPeerGradeFractals  5   	   ,    &WpfAppPeerGradeFractals.WindowGradient   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WpfAppPeerGradeFractals     5   	     � Title$  WindowGradient��5   	   $	��450��6    $	��500��6-    � 
ResizeMode$ NoResize=�69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      $	��100 �6   6+   .+�5   
   �� -   5         ��Name$ canvasColorBegin��5   C   $��0��6   $��0��6!   ���#FF0000.+�5      �� -   5         ��Name$ sliderRBegin��5   5   $	��200��6   $��
35,100,0,0q�6!    � Minimum$ 0Q�6K    � Maximum$	 255Q�6W   5   @   �� 5      -   5        $ sliderGBegin��5   5   $	��200��6   $��
35,150,0,0q�6!   $ 0Q�6K   $	 255Q�6W   5   @   �� 5      -   5        $ sliderBBegin��5   5   $	��200��6   $��
35,200,0,0q�6!   $ 0Q�6K   $	 255Q�6W   5   @   �� 5      $��	10,94,0,0q�6   $��20(�6+   ���#FFFFFFR:6R   �� 5      $��
10,144,0,0q�6   $��20(�6,   ���#FFFFFFG:6S   �� 5      $��
10,194,0,0q�6   $��20(�6,   ���#FFFFFFB:6S   �� 5      $��
50,250,0,0q�6   $��20(�6,   ���#FFFFFFНачальный цвет6_   5      �� 5   
   -   5        $ canvasColorEnd��5   C   $��1��6   $��0��6!   ���#0000FF.+�5      �� -   5        $ 
sliderREnd��5   5   $	��200��6   $��
35,100,0,0q�6!   $ 0Q�6I   $	 255Q�6U   5    >   �� 5!      -   5        $ 
sliderGEnd��5!   5   $	��200��6   $��
35,150,0,0q�6!   $ 0Q�6I   $	 255Q�6U   5"   >   �� 5#      -   5        $ 
sliderBEnd��5#   5   $	��200��6   $��
35,200,0,0q�6!   $ 0Q�6I   $	 255Q�6U   5$   >   �� 5%      $��	10,94,0,0q�6   $��20(�6+   ���#FFFFFFR:6R   �� 5&      $��
10,144,0,0q�6   $��20(�6,   ���#FFFFFFG:6S   �� 5'      $��
10,194,0,0q�6   $��20(�6,   ���#FFFFFFB:6S   �� 5(      $��
50,250,0,0q�6   $��20(�6,   ���#FFFFFFКонечный цвет6^   5)      �� 5*   
   $��0��6   $��1��6!   ���#BBBBBB.+�5+      �� -	   5         ��Name$ buttonCancel��5+   .   $	��250��6   $	��100��6!   .��6_   Отмена6g   5,      �� 5-   
   $��1��6   $��1��6!   ���#BBBBBB.+�5.      �� -
   5        $ 
buttonSave��5.   .   $	��250��6   $	��100��6!   .��6[   %#Сохранить градиент6o   5/      50      51      