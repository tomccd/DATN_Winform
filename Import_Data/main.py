import pypyodbc as odbc
import pandas as pd
import sys

#--Load dữ liệu từ Excel
try:
    print("Đang load dữ liệu từ excel nha .....")
    #--Chuyển file excel thành dataframe
    df_typeproduct = pd.read_excel('./data/Type_Product.xlsx')
    df_products = pd.read_excel('./data/Products.xlsx')
    df_weighCer = pd.read_excel('./data/Weigh_Certificate.xlsx')
    df_weighNonCer = pd.read_excel('./data/Weigh_Non_Certificate.xlsx')
    df_admin = pd.read_excel('./data/Admin.xlsx')
    df_devices = pd.read_excel('./data/Devices.xlsx')
    
    #--Chuyển dữ liệu từ dạng numpy array sang list
    
    #Type_Product
    data_id_type_product_TB_Type_Product = df_typeproduct['ID_Type_Product'].values.tolist()
    data_name_type_product_TB_Type_Product = df_typeproduct['Name_Type_Product'].values.tolist()
    
    #Products
    data_id_product_TB_Products = df_products['ID_Product'].values.tolist()
    data_id_type_product_TB_Products = df_products['ID_Type_Product'].values.tolist()
    data_name_product_TB_Products = df_products['Name_Product'].values.tolist()
    
    #Weigh_Certificate
    data_id_product_TB_Weigh_Certificate = df_weighCer['ID_Product'].values.tolist()
    data_weighs_TB_Weigh_Certificate = df_weighCer['Weighs'].values.tolist()
    
    #Weigh_Non_Certificate
    data_id_product_TB_Weigh_Non_Certificate = df_weighNonCer['ID_Product'].values.tolist()
    data_weighs_TB_Weigh_Non_Certificate = df_weighNonCer['Weighs'].values.tolist()
    
    #Admin
    data_admin_id = df_admin['id'].values.tolist()
    data_admin_name = df_admin['admin_name'].values.tolist()
    data_admin_email = df_admin['admin_email'].values.tolist() 

    #Devices
    data_devices_ip = df_devices['IP_Address'].values.tolist()
    data_devices_name = df_devices['Device_Name'].values.tolist()
    
except Exception as e:
    print(f"Lỗi đâu gòi: {e}")
    sys.exit()
else:
    print("\nOK giờ đến lượt kết nối server")

#--Kết nối với Database
DRIVER_NAME = 'SQL Server'
SERVER_NAME = 'DESKTOP-DVLLCVU'
DATABASE_NAME = 'DATN'
UID = 'nv_1'
password = '18012002'

connection_string = f"""
    DRIVER={DRIVER_NAME};
    SERVER={SERVER_NAME};
    DATABASE={DATABASE_NAME};
    uid={UID};
    pwd={password};
"""

#--Thử kết nối với server
try:
    print("\nĐang kết nối với server ....")
    conn = odbc.connect(connection_string)
except Exception as e:
    print(f"Kiểm tra lại việc kết nối nhoa {e}")
    sys.exit()
else:
    print("\nKết nối thành công")

#-- Nạp dữ liệu 

# Nạp dữ liệu cho bảng Type_Product
print("\nNạp dữ liệu bảng Type_Product nha .....")
sql_query = "INSERT INTO Type_Product (ID_Type_Product,Name_Type_Product) VALUES (?,?);"
cursor = conn.cursor()
for x in range(df_typeproduct.shape[0]):
     try:
         value = [data_id_type_product_TB_Type_Product[x],data_name_type_product_TB_Type_Product[x]]
         cursor.execute(sql_query,value)
     except Exception as e:
         print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha: {e}")
         sys.exit()
     else:
         cursor.commit()

# #Nạp dữ liệu cho bảng Products
print("\nNạp dữ liệu bảng Products nha .....")
sql_query = "INSERT INTO Products (ID_Product,ID_Type_Product,Name_Product) VALUES (?,?,?);"
for x in range(df_products.shape[0]):
     try:
         value = [data_id_product_TB_Products[x],data_id_type_product_TB_Products[x],data_name_product_TB_Products[x]]
         cursor.execute(sql_query,value)
     except Exception as e:
         print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha: {e}")
         sys.exit()
     else:
         cursor.commit()

# #Nạp dữ liệu cho bảng Weigh_Certificate
print("\nNạp dữ liệu bảng Weigh_Certificate nha .....")
sql_query = "INSERT INTO Weigh_Certificate (ID_Product,Weighs) VALUES (?,?);"
for x in range(df_weighCer.shape[0]):
     try:
         value = [data_id_product_TB_Weigh_Certificate[x],data_weighs_TB_Weigh_Certificate[x]]
         cursor.execute(sql_query,value)
     except Exception as e:
         print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha: {e}")
         sys.exit()
     else:
         cursor.commit()

# #Nạp dữ liệu cho bảng Weigh_Non_Certificate
print("\nNạp dữ liệu bảng Weigh_Non_Certificate nha .....")
sql_query = "INSERT INTO Weigh_Non_Certificate (ID_Product,Weighs) VALUES (?,?);"
for x in range(df_weighNonCer.shape[0]):
     try:
         value = [data_id_product_TB_Weigh_Non_Certificate[x],data_weighs_TB_Weigh_Non_Certificate[x]]
         cursor.execute(sql_query,value)
     except Exception as e:
         print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha {e}")
         sys.exit()
     else:
         cursor.commit()

#Nạp dữ liệu cho bảng Admin
print("\nNạp dữ liệu bảng Admin nha ...")
sql_query = "INSERT INTO Admin VALUES (?,?,?);"
for x in range(df_admin.shape[0]):
    try:
        value = [data_admin_id[x],data_admin_name[x],data_admin_email[x]]
        cursor.execute(sql_query,value)
    except Exception as e:
        print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha: {e}")
        sys.exit()
    else:
        cursor.commit()

#Nạp dữ liệu cho bảng Devices
print("\n Và cuối cùng nạp dữ liệu bảng Devices nha ...")
sql_query = "INSERT INTO Devices VALUES (?,?);"
for x in range(df_devices.shape[0]):
    try:
        value = [data_devices_ip[x],data_devices_name[x]]
        cursor.execute(sql_query,value)
    except Exception as e:
        print(f"Lỗi chèn dữ liệu. Xem lại dữ liệu nha: {e}")
        sys.exit()
    else:
        cursor.commit()
print("Xong gòi đoa, mãi iu!")