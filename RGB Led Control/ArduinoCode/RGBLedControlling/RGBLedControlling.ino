const int pinLedRed = 9;
const int pinLedGreen = 10;
const int pinLedBlue = 11;
void setup()
{
	pinMode(pinLedRed, OUTPUT);
	pinMode(pinLedGreen, OUTPUT);
	pinMode(pinLedBlue, OUTPUT);

	Serial.begin(9600);
}

void loop()
{
	if (Serial.available() == 3)
	{
		int a = Serial.read();
		int b = Serial.read();
		int c = Serial.read();

		setColor(a, b, c);
	}

}

void setColor(int a, int b, int c){
	analogWrite(pinLedRed, a);
	analogWrite(pinLedGreen, b);
	analogWrite(pinLedBlue, c);
}
