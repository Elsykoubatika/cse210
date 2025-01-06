import qrcode

# URL à encoder dans le QR code
url = "https://play.google.com/store/apps/details?id=com.cowema.ve"

# Génération du QR code
qr_code = qrcode.QRCode(
    version=1,
    error_correction=qrcode.constants.ERROR_CORRECT_L,
    box_size=10,
    border=4,
)
qr_code.add_data(url)
qr_code.make(fit=True)

# Création de l'image du QR code
img = qr_code.make_image(fill_color="black", back_color="white")

# Enregistrement de l'image
file_path = "/mnt/data/COWEMA_QR_code.png"
img.save(file_path)

file_path