FROM python:3.7.1-alpine3.7

# Install alpine necessarily packages to install pip packages
RUN apk add --no-cache g++ unixodbc-dev 

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Install any needed packages specfified in requirements.txt
RUN pip install --trusted-host pypi.python.org -r requirements.txt

# Make port 9090 available to the world outside this container
EXPOSE 9090

ENV SERVER_PORT=9090

# Run app.py when the container launches
CMD ["python", "app.py"]
