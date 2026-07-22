#include <SPI.h>
#include <RF24.h>

// ===== ESP32-S3 NODE 1 =====
#define IS_NODE_1 true

// NRF Pins
constexpr uint8_t CE_PIN  = 17;
constexpr uint8_t CSN_PIN = 5;

// Custom SPI Pins for ESP32-S3
constexpr uint8_t SCK_PIN  = 12;
constexpr uint8_t MISO_PIN = 13;
constexpr uint8_t MOSI_PIN = 11;

RF24 radio(CE_PIN, CSN_PIN);

const byte address1[6] = "NODE1";
const byte address2[6] = "NODE2";

struct __attribute__((packed)) Msg {
  char text[32];
};

Msg msg;

void setup() {
  Serial.begin(115200);

  // Start custom SPI
  SPI.begin(SCK_PIN, MISO_PIN, MOSI_PIN);

  if (!radio.begin()) {
    Serial.println("❌ NRF not responding");
    while (1);
  }

  radio.setChannel(108);
  radio.setDataRate(RF24_250KBPS);
  radio.setPALevel(RF24_PA_LOW);
  radio.setCRCLength(RF24_CRC_16);

  radio.openWritingPipe(address2);
  radio.openReadingPipe(1, address1);

  radio.startListening();

  Serial.println("🟢 ESP32-S3 (NODE1) Chat Ready");
}

void loop() {

  // Receive
  if (radio.available()) {
    Msg incoming;
    radio.read(&incoming, sizeof(incoming));
    Serial.print("📩 ");
    Serial.println(incoming.text);
  }

  // Send
  if (Serial.available()) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    if (input.length() > 31) {
      Serial.println("⚠ Max 31 chars");
      return;
    }

    input.toCharArray(msg.text, 32);

    radio.stopListening();
    bool ok = radio.write(&msg, sizeof(msg));
    radio.startListening();

    if (ok) Serial.println("📤 Sent");
    else Serial.println("❌ SendFailed");
  }
}