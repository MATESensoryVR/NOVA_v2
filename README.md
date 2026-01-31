
## 🎥 Demo Video

Watch the demo here:  
▶️ https://www.youtube.com/watch?v=AkVC9J5gZTY

---

## ✅ Requirements

### Unity
- **Unity Version:** `2022.3.62f2 (LTS)`  
  Use this exact version whenever possible to avoid serialization or package compatibility issues.

### Android Build Support (required)
In **Unity Hub → Installs → (your Unity version) → Add modules**, ensure these are installed:
- Android Build Support
- Android SDK & NDK Tools
- OpenJDK

### XR SDK
- **XR SDK:** **PICO Integration `3.0.5`** (local package)
- This project uses a **local package** stored under:
  - `Packages/PICO_Integration_3.0.5/...`
- If Unity reports that the PICO package is missing, check:
  - `Packages/manifest.json` points to the local package using a **relative `file:` path**.

---

## 🛠️ Build Instructions (Android)

### Step-by-step
1. Clone this repository:
   ```bash
   git clone https://github.com/MATESensoryVR/NOVA_v2.git
````

2. Open the project using **Unity Hub** with Unity `2022.3.62f2 (LTS)`.
3. In Unity: **File → Build Settings**

   * Select **Android**
   * Click **Switch Platform**
4. Build:

   * **Build** (APK), or
   * **Build App Bundle** (AAB)

---

## ⚙️ Project Settings (Important / Crash-Prone)

Changing these settings may cause **black screen**, **startup crash**, or **installation failure** on Android VR devices.

### 1) Graphics API

Unity: **Edit → Project Settings → Player → Android → Other Settings**

* Keep **OpenGLES3** enabled.
* Avoid removing OpenGLES3 unless you have fully validated Vulkan on your target device.

### 2) Scripting Backend & CPU Architectures

Unity: **Player → Android → Other Settings**

* **Scripting Backend:** **IL2CPP**
* **Target Architectures:** enable **ARM64**

  * Disabling ARM64 can cause runtime failure on modern XR devices.

### 3) Android API Levels

Unity: **Player → Android → Other Settings**

* **Minimum API Level:** **Android 10.0 (API 29)** or higher (recommended for XR)
* **Target API Level:** **Automatic (highest installed)** is acceptable


### 6) Signing / Publishing

Unity: **Player → Publishing Settings**

* Use your own keystore for release signing.
* **No signing password is published in this repository.**

---

## 📧 Contact

Email: **[tao.chengfang@phd.uni-mate.hu]**

```
