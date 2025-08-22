# 🚀 Roadmap

## ✅ المرحلة الأولى: أساسيات الـ User
- [x] ربط المشروع مع MongoDB.  
- [x] إنشاء **User Entity** + Repository.  
- [x] عمل **Register User** (مع Password Hash).  
- [x] عمل **Login User** باستخدام JWT.  
- [ ] إضافة **Get Profile** (باستخدام JWT).  

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
