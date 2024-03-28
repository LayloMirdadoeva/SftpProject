using Renci.SshNet;
using File = System.IO.File;

var host = "127.0.0.1";
var username = "Laylo";
var password = ""; //enter your server password

var localPath = "C:\\Users\\Laylo\\Desktop\\Eskhata\\Archives\\example.xml";
var remotePath = @"\sftpPath\example.xml";

var client = new SftpClient(host,22, username, password);
void sendAndDownloadFileToSftpServer (string local, string remote)
{
    client.Connect();
    send(local, remote);
    download(@"D:\laylohon.xml");
    client.Disconnect();
    
}

void send(string local, string remote) {
    var fileStream = new FileStream(local, FileMode.Open);
    client.UploadFile(fileStream, remote);
    Console.WriteLine("The file upload to server!");
}
void download(string downloadFile)
{
    Stream fileStream = File.Create(downloadFile);
    client.DownloadFile(@"\sftpPath\example.xml", fileStream);
    Console.WriteLine("The file download at server!");
}
sendAndDownloadFileToSftpServer(localPath, remotePath); 