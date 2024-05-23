#include "DW3000.h"

static int frame_buffer = 0; // Variable to store the transmitted message
static int rx_status; // Variable to store the current status of the receiver operation
static int tx_status; // Variable to store the current status of the receiver operation

void setup()
{
  Serial.begin(115200); // Init Serial
  DW3000.begin(); // Init SPI 
  DW3000.hardReset(); // hard reset in case that the chip wasn't disconnected from power
  delay(200); // Wait for DW3000 chip to wake up
  while (!DW3000.checkForIDLE()) // Make sure that chip is in IDLE before continuing 
  {
    Serial.println("[ERROR] IDLE1 FAILED\r");
    while (100);
  }
  DW3000.softReset(); // Reset in case that the chip wasn't disconnected from power
  delay(200); // Wait for DW3000 chip to wake up

  if (!DW3000.checkForIDLE())
  {
    Serial.println("[ERROR] IDLE2 FAILED\r");
    while (100);
  }

  DW3000.init(); // Initialize chip (write default values, calibration, etc.)
  DW3000.setupGPIO(); //Setup the DW3000s GPIO pins for use of LEDs
  
  Serial.println("> PONG with timestamp example <\n");

  Serial.println("[INFO] Setup finished.");

  DW3000.configureAsTX(); // Configure basic settings for frame transmitting
}

void loop()
{
  /**       === Await PING ===        **/
  DW3000.standardRX(); // Send command to DW3000 to start the reception of frames

  while (!(rx_status = DW3000.receivedFrameSucc())) 
  {}; // Wait until frame was received
  
  if (rx_status == 1) { // If frame reception was successful
    
    //Serial.println("\n\n    === Received PING ===\n");

    DW3000.prepareDelayedTX();
    DW3000.delayedTX();

      /**       === Send PONG ===        **/
    
    DW3000.pullLEDHigh(2);
    while (!(tx_status = DW3000.sentFrameSucc()))
    {
      //Serial.println("[ERROR] PONG could not be sent succesfully!");
    };
    
    DW3000.clearSystemStatus(); // Clear event status
  
    //Serial.println("\n[INFO] Sent PONG successfully.");
    
    //DW3000.calculateRXTXdiff(); // Print information on the sent data for debug purposes
    DW3000.pullLEDLow(2);
  }
  else // if rx_status returns error (2)
  {
    Serial.println("[ERROR] Receiver Error occured! Aborting event.");
    DW3000.clearSystemStatus();
  }
}
