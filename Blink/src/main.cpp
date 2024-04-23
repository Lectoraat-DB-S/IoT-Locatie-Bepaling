

#include <Arduino.h>

#include <wifi.h> 

#define LED 2

// WiFi credentials.
const char* WIFI_SSID = "wifi-ssid";
const char* WIFI_PASS = "wifi-password";

void setup()
{
    Serial.begin(115200);
  pinMode(LED, OUTPUT);
    // Giving it a little time because the serial monitor doesn't
    // immediately attach. Want the firmware that's running to
    // appear on each upload.
    delay(2000);

    Serial.println();
    Serial.println("Running Firmware.");

    // Connect to Wifi.
    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(WIFI_SSID);

    // Set WiFi to station mode and disconnect from an AP if it was previously connected
    WiFi.mode(WIFI_STA);
    WiFi.disconnect();
    delay(100);

    WiFi.begin(WIFI_SSID, WIFI_PASS);
    Serial.println("Connecting...");

    while (WiFi.status() != WL_CONNECTED) {
      // Check to see if connecting failed.
      // This is due to incorrect credentials
      if (WiFi.status() == WL_CONNECT_FAILED) {
        Serial.println("Failed to connect to WIFI. Please verify credentials: ");
        Serial.println();
        Serial.print("SSID: ");
        Serial.println(WIFI_SSID);
        Serial.print("Password: ");
        Serial.println(WIFI_PASS);
        Serial.println();
      }
      delay(5000);
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());

    Serial.println("Hello World, I'm connected to the internets!!");
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(LED, HIGH);
  Serial.println("LED is on");
  delay(1000);
  digitalWrite(LED, LOW);
  Serial.println("LED is off");
  delay(1000);
}