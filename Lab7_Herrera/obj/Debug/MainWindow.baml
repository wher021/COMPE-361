   M S B A M L   `   `   `  ����  WpfApplication2     WpfApplication2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      � ���	#FFA8F596 � RowDefinitions 5   
   �� 5      $��30 �6   �� 5	       � ColumnDefinitions 5   
   �� 5      $
��243* �6   �� 5      $	��15* �6   �� 5      $
��259* �6   .+�5   
   `� $��0��6   .�5      c� .@�5      o� .@�5      m� $
��Menu��6   ��.  .@�5      m� -   5        $��Instructions��5   #   ��.  6f   5      5      5      5      �� 5   
   $��1��6   $��Chaining/Result Box��6    $��Stretch=�6=   $��5q�6[   $��Stretch=�6f   $
��auto��6�   $
��auto��6�   $��2��6�   .��5      � -   5         �Name$ 	GroupGrid��5      $��Stretch=�6&   $
��auto��6D   $��Stretch=�6R   $
��auto��6n    5      �� 5      $	��17* �6'   �� 5      $	��42* �6'   �� 5      $	��59* �6'   �� 5      $	��59* �6'   �� 5       $	��59* �6'    5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      .+�5/      �� -   5         ��Name$ chainBox��5/      $��0��6,   $��4��6=   $��Stretch=�6Q   $
��auto��6o   $��	5,5,5,4.7q�6}   $��0��6�    �� TextWrapping$
 Wrap=�6�   $��Stretch=�6�   $
��auto��6�   |�.   �� 
IsReadOnly . ��.  6�   �� 50      -   5        $ sumBox��50      $��4��6*   $��Stretch=�6>   $
��auto��6\   $��5,5.3,5,4.7q�6j   $��1��6   $
 Wrap=�6�   $��Stretch=�6�   $
��auto��6�   ��.   . |�.  6�   �� 52      -   5         ��Name$ label1��52      $
��Real��6(   $��1��67   $��0��6D   $��Stretch=�6T   $��Bottom=�6p   $��Stretch=�6�   $��2��6�   $��0,25.3,0,0.7q�6�   $��2��6�   �� 53      -   5        $ label2��53      $
��Imag��6(   $��Stretch=�67   $��1��6U   $��3��6b   $��Bottom=�6r   $��0,25.3,0,0.7q�6�   $��2��6�   �� 54      -   5        $ realBox��54      $��3��6+   $��Stretch=�6?   $
��auto��6^   $��5,4.3,5,5.4q�6l   $��3��6�   $
 Wrap=�6�   $��Stretch=�6�   $
��auto��6�   -  'System.Windows.Input.KeyboardNavigation   TabIndex$ 0��6�   6  �� 55      -	   5        $ imagBox��55      $��3��6+   $��2��6;   $��Stretch=�6O   $
��auto��6m   $��5,5.3,5,4.4q�6{   $��3��6�   $
 Wrap=�6�   $��Stretch=�6�   $
��auto��6�   $ 1��6�   6  �� 56      -
   5        	 ��Name$	 button1��56      $��1��6*   $��2,1.6,2,2.4q�66   $��0��6K   $��4��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  $��2��6�   6�   �� 57      -   5        $	 button2��57      $��2��6*   $��2,1.6,2,2.4q�66   $��2��6K   $��4��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 58      -   5        $	 button3��58      $��3��6*   $��2,1.6,2,2.4q�66   $��3��6K   $��4��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 59      -   5        $	 button4��59      $��4��6*   $��2,1.6,2,2.4q�66   $��0��6K   $��5��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  $��2��6�   �� 5:      -   5        $	 button5��5:      $��5��6*   $��2,1.6,2,2.4q�66   $��2��6K   $��5��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5;      -   5        $	 button6��5;      $��6��6*   $��2,1.6,2,2.4q�66   $��3��6K   $��5��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5<      -   5        $	 button7��5<      $��7��6*   $��2,1.6,2,2.4q�66   $��0��6K   $��6��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  $��2��6�   �� 5=      -   5        $	 button8��5=      $��8��6*   $��2,1.6,2,2.4q�66   $��2��6K   $��6��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5>      -   5        $	 button9��5>      $��9��6*   $��2,1.6,2,2.4q�66   $��3��6K   $��6��6[   $��Stretch=�6h   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5?      -   5        $	 	addButton��5?      $��+��6,   $��2,1.6,2,2.4q�68   $��0��6M   $��7��6]   $��Stretch=�6j   $�� auto��6�   $
��auto��6�   ��.  $��2��6�   �� 5@      -   5        $	 	subButton��5@      $��-��6,   $��2,1.6,2,2.4q�68   $��2��6M   $��7��6]   $��Stretch=�6j   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5A      -   5        $	 multiButton��5A      $��*��6.   $��2,1.6,2,2.4q�6:   $��3��6O   $��7��6_   $��Stretch=�6l   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5B      -   5        $	 	divButton��5B      $��/��6,   $��2,1.6,2,2.4q�68   $��0��6M   $��8��6]   $��Stretch=�6j   $�� auto��6�   $
��auto��6�   ��.  $��2��6�   �� 5C      -   5        $	 clearButton��5C      $��CE��6.   $��2,1.6,2,2.4q�6;   $��2��6P   $��8��6`   $��Stretch=�6m   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5D      -   5        $	 restartButton��5D      $��c��60   $��2,1.6,2,2.4q�6<   $��3��6Q   $��8��6a   $��Stretch=�6n   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5E      -   5        $	 button15��5E      $��=��6+   $��2��67   $��2,1.6,2,2.4q�6K   $��2��6`   $��9��6p   $��Stretch=�6}   $�� auto��6�   $
��auto��6�   ��.  6�   �� 5F      -   5        $��0��5F      $��2,1.6,2,2.4q�6%   $��0��6:   $��9��6J   $��Stretch=�6W   $�� auto��6u   $
��auto��6�   ��.  $��2��6�   5G      5H      �� 5I   
   $��1��6   $��2��6"   $��Stretch=�62   $
��auto��6P   $��30q�6^   $��Stretch=�6j   $
��auto��6�   .+�5J      �� -   5        
 ��Name$
 modeBox��5J      ��.  .@�5K      �� $��Rectangular��6   �� 5L      $��Polar��6   5M      �� 5N      -   5         ��Name$ 	memoryBox��5N      $	��100��6)   66   �� 5O      $��Memory Controls��6   $��Stretch=�6.   �� 5P      -   5        $	 memoryButton��5P      $��M+��6+   68   �� 5Q      -   5        $	 removeMemoryButton��5Q      $��M-��61   6>   5R      5T      5U      