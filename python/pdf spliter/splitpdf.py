from PyPDF2 import PdfWriter, PdfReader
def start():
    try:
        print("\n\n\n")
        print(" PDF Spliter ".center(40,"+"))
        inputpf=input("Enter the pdf name with path : ")
        if(inputpf.lower()=="exit"):
            print("Program exit...")
            exit()
        inputpdf = PdfReader(open(f"{inputpf}", "rb"))
        pdfname=input("Enter The Output Pdf fileName : ")
        if(pdfname.lower()=="exit"):
            print("Program exit...")
            exit()
        get1=input(f"Your PDF Total Pages : {len(inputpdf.pages)} \n1.Use - To Extract range of pdf pages(input :  1-4 extract from pdf page 1 to page 4)\n2.Use , to extract specific pages(input : 1,3,4 extract pdf page 1, page 3, page 4)\n3.use single number for single pdf page extract (input : 1)\n4.Type Exit To quit the program\nEnter The Input : ")
        output = PdfWriter()
        if("-" in get1):
            get = get1.split('-')
            if(int(get[0])>0 and int(get[1])>0 and int(get[1])<=len(inputpdf.pages) and int(get[0])<=len(inputpdf.pages) and int(get[0])<int(get[1])):
                for i in range(int(get[0])-1,int(get[1])):
                    output.add_page(inputpdf.pages[i])
                    with open(f"{pdfname}.pdf", "wb") as outputStream:
                        output.write(outputStream)
                print(f"{pdfname}.pdf created successfully")
                start()
            else:
                print("Enter The Input Correctly")
                start()
        elif("," in get1):
            get = get1.split(',')
            for i in get:
                output.add_page(inputpdf.pages[int(i)-1])
                with open(f"{pdfname}.pdf", "wb") as outputStream:
                    output.write(outputStream)
            print(f"{pdfname}.pdf created successfully")
            start()
        else:
            if(get1.lower()=="exit"):
                print("Program exit...")
                exit()
            elif(int(get1)>0 and int(get1)<=len(inputpdf.pages)):
                output.add_page(inputpdf.pages[int(get1)-1])
                with open(f"{pdfname}.pdf", "wb") as outputStream:
                    output.write(outputStream)
                print(f"{pdfname}.pdf created successfully")
                start()
            else:
                print("Enter The Input Correctly")
                start()
    except Exception as e:
        print(f"enter the input correctly ....\n{e}")
        start()
start()