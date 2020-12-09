/* Mingye Chen 2020-12-08
 * Sends button and flex sensor data to Unity game engine
 */
#define UPDATE_SPEED 50 // Time interval for sending data in milliseconds
int flexSensorPin = A0; // Analog pin 0
int orientationButton = 2; // Digital pin 2
boolean orientatedRight = true, buttonPressed = false; // Button States
int lastUpdated = millis();
void setup(){
  Serial.begin(9600);
  pinMode(orientationButton, INPUT);
}

void loop(){
  // Button logic to only register click when pressed and released
  if(!buttonPressed && digitalRead(orientationButton) == HIGH) {
      orientatedRight = !orientatedRight;
      buttonPressed = true;
  }
  if(digitalRead(orientationButton) == LOW) buttonPressed = false;
  // Runs every 50 millis
  if(millis() - lastUpdated > UPDATE_SPEED){
    // Read flex sensor value
    int flexSensorReading = analogRead(flexSensorPin);
    char dataStr[8];
    //Construct string with flex and button data
    sprintf(dataStr, "[%d,%d]", flexSensorReading, (int)orientatedRight);
    Serial.println(dataStr);
    // Reset timer
    lastUpdated = millis();
  }
}
