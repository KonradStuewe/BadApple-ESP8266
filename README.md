# BadApple-ESP8266

Plays the Bad Apple intro on the ESP8266.  
Display used: I2C OLED 128x64 SH1106

Requires the U8G2 display library.

As is the program uses >98% of the available `PROGMEM`.

# Etc

The zip `Video2Bits2` contains the program that converts the video to an array of `uint` that then can be used for the ESP8266.  
Why is it a zip? Github didn't want to upload the whole folder. And I'm to lazy to check if everything is there. So: zip
