# BigBang2
Codes of Big Bang Assessment2
Apollo Hospitals
Description:
This project includes three roles those are [Patient, Doctor, and Admin]. Patients can do registration, after login. Patients can place an appointment by viewing all the doctors based on their needs.Doctor can update his/her own details and can view the appointments of him/her. Doctors needs an approval by Admin . Admin can approve or decline the request of doctor.
Database:
4 Tables,
1.User
The purpose of user table is login of an user based on theri role.
2.Doctor
If the patients registers, there is no approval. So initially their details will be posted in user table then by the trigger it will be posted on patient table.
3.Patient
If a doctor registers, those details will be posted to user table and doctor table by trigger only if admin accepts.
4.Appointment
In the Appointment table , the booking will be there.
5.Feedback
Feedbacks by the patients will be there.

I implemented all the needed endpoints.
