# 🚗 CarClinic API

CarClinic هو مشروع API مبني باستخدام **.NET 8** و **Clean Architecture** مع **MongoDB**.  
المشروع يوفر نظام لإدارة خدمات مراكز صيانة السيارات (Car Clinic).

---

## ✨ Features
- User Authentication (Client / Admin).
- Car Management.
- Service Management (Add, Update, Delete).
- Appointment Booking & Tracking.
- Invoice Generation.
- Reports (basic statistics).
- JWT Authentication.
- MongoDB Integration.

---

## 🏗️ Architecture
- **Domain Layer**: Entities, Interfaces, Business Rules.
- **Application Layer**: UseCases, DTOs, Services.
- **Infrastructure Layer**: MongoDB, Repositories, Authentication.
- **Presentation Layer**: API Controllers.

---

## 📌 Roadmap
1. Setup Project Structure.
2. Define Domain Entities.
3. Configure MongoDB (Infrastructure).
4. Implement Authentication (JWT).
5. Implement Use Cases (Application).
6. Add Controllers (Presentation).
7. Add Unit & Integration Tests.
8. Documentation (Swagger + README).

---

## 📂 Project Structure

├── CarClinic.Domain
├── CarClinic.Application
├── CarClinic.Infrastructure
├── CarClinic.Presentation
└── README.md


---

## 🔮 Future Enhancements
- Notifications via Email/SMS.
- Rating & Feedback System.
- Subscription Packages.
- AI-based Maintenance Suggestions.



# 🚀 Roadmap

## ✅ المرحلة الأولى: أساسيات الـ User
- [x] ربط المشروع مع MongoDB.  
- [x] إنشاء **User Entity** + Repository.  
- [x] عمل **Register User** (مع Password Hash).  
- [x] عمل **Login User** باستخدام JWT.  
- [x] إضافة **Get Profile** (باستخدام JWT).  

---

## 🛠️ المرحلة الثانية: إدارة المستخدمين (User Management)
- [ ] Endpoint: Get User by Id (Admin only).  
- [ ] Endpoint: Get All Users (Admin only).  
- [ ] Endpoint: Update User Profile.  
- [ ] Endpoint: Delete User (Admin only).  

---

## 🚗 المرحلة الثالثة: السيارات (Car Management)
- [ ] إنشاء **Car Entity**.  
- [ ] Repository + UseCases (Add / Get / Update / Delete).  
- [ ] Controllers للسيارات (ربط كل عربية بيوزر).  

---

## 🛠️ المرحلة الرابعة: الخدمات (Service Management)
- [ ] إنشاء **Service Entity** (مثال: تغيير زيت، فحص فرامل...).  
- [ ] UseCases + Repository (Add / Get / Update / Delete).  
- [ ] Controllers (إدارة الخدمات – Admin only).  

---

## 📅 المرحلة الخامسة: المواعيد (Appointments)
- [ ] إنشاء **Appointment Entity** (يوزر + خدمة + تاريخ + حالة).  
- [ ] UseCases (Book Appointment, Update Status).  
- [ ] Endpoints:  
  - User يحجز ميعاد.  
  - Admin يغير حالة الميعاد (pending → in-progress → completed).  
  - User/Admin يشوف المواعيد الخاصة بيه.  

---

## 💰 المرحلة السادسة: الفواتير (Invoices)
- [ ] إنشاء **Invoice Entity**.  
- [ ] توليد فاتورة تلقائيًا بعد انتهاء الصيانة.  
- [ ] Endpoints: Get Invoice By Appointment, Get All Invoices (Admin).  

---

## 📊 المرحلة السابعة: التقارير (Reports)
- [ ] تقرير بعدد الحجوزات.  
- [ ] تقرير بالخدمات الأكثر طلبًا.  
- [ ] تقرير بأرباح العيادة.  

---

## 🌟 المرحلة الثامنة: تحسينات مستقبلية
- [ ] Notifications (Email/SMS).  
- [ ] Rating & Feedback من العميل.  
- [ ] Subscription Packages.  
- [ ] AI Suggestions للصيانة الدورية.  

---

# 🏁 ترتيب التنفيذ العملي
1. ✅ Users (Register + Login + Profile).  
2. 🛠️ User Management.  
3. 🚗 Car Management.  
4. 🛠️ Service Management.  
5. 📅 Appointments.  
6. 💰 Invoices.  
7. 📊 Reports.  
8. 🌟 Future Enhancements.
