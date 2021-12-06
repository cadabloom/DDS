# DDS

Requires
NET 5.0

Runbook
- Set Api as startup project
- User swagger ui to execute api -> [base-url]/swagger/index.html
- Use Auth(POST /Auth) to get a token (user:testclient password:clientpassword)
- Click Authorize and paste the token value from /Auth
- Use Patients(POST/PUT/GET/DELETE) 
