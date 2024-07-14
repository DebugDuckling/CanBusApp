import os

# Define the directory containing the project files
project_dir = '.'
output_file = 'combined_project.txt'

# Define the file extensions to include in the combined file
file_extensions = ['.cs', '.json', '.csproj', '.config', '.xml', '.xaml', '.resx']

# Define a function to check if a file should be included
def should_include_file(file_name):
    return any(file_name.endswith(ext) for ext in file_extensions)

# Open the output file for writing
with open(output_file, 'w', encoding='utf-8') as outfile:
    # Walk through the directory
    for root, dirs, files in os.walk(project_dir):
        for file in files:
            if should_include_file(file):
                file_path = os.path.join(root, file)
                # Write the file name as a comment
                outfile.write(f'# {file}\n')
                # Write the file content
                with open(file_path, 'r', encoding='utf-8') as infile:
                    outfile.write(infile.read())
                # Add a separator between files
                outfile.write('\n\n')

print(f'Combined project files into {output_file}')
