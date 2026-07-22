# RF-Shield - Secure Bidirectional Wireless Communication System for Real-Time Data Exchange

<div align="center">

![RF-Shield](docs/images/Demo_Time.png)

**A secure RF-based chat application that enables real-time wireless communication without internet, cellular, or Wi-Fi infrastructure.**

![Platform](https://img.shields.io/badge/Platform-ESP32--S3-blue)
![RF](https://img.shields.io/badge/Communication-NRF24L01-green)
![Desktop](https://img.shields.io/badge/Desktop-C%23_.NET_WinForms-purple)
![Status](https://img.shields.io/badge/Status-Completed-success)

</div>

---

## Project Overview

RF-Shield is a **Secure Bidirectional Wireless Communication System** developed as an academic networking and IoT project. The system uses **ESP32-S3 microcontrollers** and **NRF24L01 radio transceivers** to exchange encrypted text messages over radio frequency channels without relying on internet connectivity.

The desktop application provides authentication, message management, and a user-friendly chat interface for secure communication.

---

## Key Features

* Real-time bidirectional RF communication
* Internet-free messaging system
* User authentication (username, password, secure key)
* End-to-end encrypted message transmission
* Desktop chat application built with C# .NET WinForms
* NRF24L01 long-range wireless communication
* ESP32-S3 embedded firmware implementation
* Lightweight and portable architecture

---

## System Architecture

![Block Diagram](docs/images/block-diagram.png)

### Communication Flow

1. User enters credentials in the desktop application.
2. Message is encrypted in the application layer.
3. ESP32-S3 sends the encrypted payload through NRF24L01.
4. Remote node receives the RF packet.
5. Payload is decrypted and displayed in the recipient chat window.

---

## Hardware Components

| Component                    | Quantity |
| ---------------------------- | -------: |
| ESP32-S3                     |        2 |
| NRF24L01 Transceiver         |        2 |
| USB Power / Adapter          |        2 |
| Jumper Wires                 | Multiple |
| Breadboard / Prototype Board |        1 |

---

## Hardware Setup

![Hardware Setup](docs/images/hardware-setup.jpg)

---

## Desktop Application

### Login Interface

![Login](docs/images/desktop-login.png)

### Chat Interface

![Chat](docs/images/desktop-chat.png)

---

## Technology Stack

### Embedded

* ESP32-S3
* Arduino Framework
* SPI Communication
* RF24 Library

### Desktop

* C#
* .NET WinForms
* Visual Studio

### Communication

* NRF24L01 2.4 GHz RF
* Bidirectional packet-based communication

---

## Repository Structure

```text
RF-Shield/
├── firmware/
│   ├── transmitter/
│   └── receiver/
├── desktop-app/
│   └── RFShield-WinForms/
├── hardware/
├── docs/
│   ├── images/
│   └── report/
├── README.md
└── LICENSE
```

---

## Installation

### Firmware

1. Open the transmitter or receiver `.ino` file in Arduino IDE.
2. Install **ESP32 Board Package**.
3. Install the **RF24** library.
4. Select **ESP32-S3 Dev Module**.
5. Upload the firmware to each ESP32 device.

### Desktop Application

1. Open `RFShield-WinForms.sln` in Visual Studio.
2. Restore NuGet packages.
3. Build the solution.
4. Run the application.

---

## Security Considerations

* Application-layer message encryption
* Credential-based authentication
* Isolated RF communication channel
* No dependency on public internet infrastructure

---

## Academic Context

**University:** University of Kelaniya, Sri Lanka
**Degree:** BICT (Hons) — Network Technology
**Project Type:** IoT / Wireless Communication / Cybersecurity Integration

---

## Future Improvements

* AES-256 hardware-accelerated encryption
* Multi-user mesh communication
* File transfer support
* Message integrity verification
* Mobile companion application
* Frequency hopping implementation

---

## Author

**Aadhityan Thiyagarajah**
BICT (Hons) — Network Technology
University of Kelaniya

* GitHub: https://github.com/YOUR_USERNAME
* LinkedIn: https://linkedin.com/in/YOUR_LINKEDIN

---

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.
