import os
from distutils.version import StrictVersion

contracts_dir = './Contracts'
packages_dir = '../../packages'

google_protobuf_tools_path = packages_dir+'/google.protobuf.tools'
protoc_path = google_protobuf_tools_path+'/%s/tools/windows_x64/protoc.exe'

grpc_tools_path = packages_dir+'/grpc.tools'
grpc_csharp_plugin_path = grpc_tools_path+'/%s/tools/windows_x64/grpc_csharp_plugin.exe'

protoc_command = '"%s" -I '+contracts_dir+' -I %s --csharp_out %s %s --grpc_out %s --plugin=protoc-gen-grpc="%s"'

def main():
    set_protoc_path()
    set_grpc_csharp_plugin_path()
    
    for root, dirs, files in os.walk(contracts_dir):
        for file in files:
            if file.endswith('.proto'):
                generate_proto(root, file)

def set_protoc_path():
    global google_protobuf_tools_path, protoc_path
    google_protobuf_tools_dir = get_highest_version_folder(google_protobuf_tools_path)
    protoc_path = protoc_path % google_protobuf_tools_dir

def set_grpc_csharp_plugin_path():
    global grpc_tools_path, grpc_csharp_plugin_path
    grpc_tools_dir = get_highest_version_folder(grpc_tools_path)
    grpc_csharp_plugin_path = grpc_csharp_plugin_path % grpc_tools_dir
    
def get_highest_version_folder(package_dir):
    dirs = os.listdir(package_dir)
    dirs.sort(key=StrictVersion, reverse=True)
    return dirs[0]

def generate_proto(root, file):
    global protoc_command
    rpc_dir = root.replace('Contracts', 'RPC')
    if not os.path.exists(rpc_dir):
        os.makedirs(rpc_dir)
    command = protoc_command % (protoc_path, root, rpc_dir, os.path.join(root, file), rpc_dir, grpc_csharp_plugin_path)
    os.popen(command)

main()
