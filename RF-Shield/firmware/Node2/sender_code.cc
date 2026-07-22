#include <SPI.h>
#include <RF24.h>

// ===== NORMAL ESP32 NODE 2 =====
#define IS_NODE_1 false

constexpr uint8_t CE_PIN  = 17;
constexpr uint8_t CSN_PIN = 5;

RF24 radio(CE_PIN, CSN_PIN);

const byte address1[6] = "NODE1";
const byte address2[6] = "NODE2";

struct __attribute__((packed)) Msg {
  char text[32];
};

Msg msg;

void setup() {
  Serial.begin(115200);

  // Normal ESP32 uses default SPI pins:
  // SCK 18, MISO 19, MOSI 23
  SPI.begin();

  if (!radio.begin()) {
    Serial.println("❌ NRF not responding");
    while (1);
  }

  radio.setChannel(108);
  radio.setDataRate(RF24_250KBPS);
  radio.setPALevel(RF24_PA_LOW);
  radio.setCRCLength(RF24_CRC_16);

  radio.openWritingPipe(address1);
  radio.openReadingPipe(1, address2);

  radio.startListening();

  Serial.println("🔵 ESP32 (NODE2) Chat Ready");
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
    else Serial.println("❌ Send_Failed");
  }
}