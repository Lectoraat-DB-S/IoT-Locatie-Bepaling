
#include <Arduino.h>

#include "Wifi.h" 

#define LED 2

const char* ssid = "yourNetworkName";
const char* password = "yourNetworkPassword";

void setup(){
    Serial.begin(115200);
  pinMode(LED, OUTPUT);
    delay(1000);

    WiFi.mode(WIFI_STA); //Optional
    WiFi.begin(ssid, password);
    Serial.println("\nConnecting");

    while(WiFi.status() != WL_CONNECTED){
        Serial.print(".");
        delay(100);
    }

    Serial.println("\nConnected to the WiFi network");
    Serial.print("Local ESP32 IP: ");
    Serial.println(WiFi.localIP());
}



void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(LED, HIGH);
  //Serial.println("LED is on");
  delay(1000);
  digitalWrite(LED, LOW);
 //Serial.println("LED is off");
  delay(1000);
}