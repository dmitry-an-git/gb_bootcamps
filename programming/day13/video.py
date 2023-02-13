import cv2

face_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")
 
# img = cv2.imread('face.jpg')
# img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# faces = face_cascades.detectMultiScale(img_gray) #look for rectangle with the face
# print(faces) 

# for (x,y,w,h) in faces:
#     cv2.rectangle(img_gray, (x,y), (x+w, y+h), (0,0,255),1)

# cv2.imshow("Result", img_gray)
# cv2.waitKey(1000)
 
cap = cv2.VideoCapture(0) # can put filename in the brackets

while True:
    success, frame = cap.read()
    img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = face_cascades.detectMultiScale(img_gray) #look for rectangle with the face

    for (x,y,w,h) in faces:
        cv2.rectangle(frame, (x,y), (x+w, y+h), (255,0,0),2)

    cv2.imshow("Result", frame)

    if cv2.waitKey(1) & 0xff == ord("q"): # exit when press q
        break