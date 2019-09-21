using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


//
//
//
class sharpDGILib
{
    //
    //
    //
    static class Discovery
    {
        // Discovery commands

	    // DECLDIR void Initialize(uint32_t* handlep);        
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize(out UInt32 handle);

        // DECLDIR void UnInitialize(uint32_t handle);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnInitialize(UInt32 handle);
	    
	    // DECLDIR void initialize_status_change_notification(uint32_t* handlep);
	    // DECLDIR void uninitialize_status_change_notification(uint32_t handle);

	    // DECLDIR void RegisterForDeviceStatusChangeNotifications(uint32_t handle, DeviceStatusChangedCallBack edbgDeviceStatusChangedCallBack);
	    // DECLDIR void UnRegisterForDeviceStatusChangeNotifications(uint32_t handle, DeviceStatusChangedCallBack edbgDeviceStatusChangedCallBack);
	    // DECLDIR void register_for_device_status_change_notifications(uint32_t handle, DeviceStatusChangedCallBack deviceStatusChangedCallBack);
	    // DECLDIR void unregister_for_device_status_change_notifications(uint32_t handle, DeviceStatusChangedCallBack deviceStatusChangedCallBack);
	
	    // DECLDIR void discover(void);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void discover();

	    // DECLDIR int get_device_count(void);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_device_count();

	    // DECLDIR int get_device_serial(int index, char* sn);
        [DllImport("dgilib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_device_serial(int index, StringBuilder sn);

	    // DECLDIR int get_device_name(int index, char* name);
        [DllImport("dgilib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_device_name(int index, StringBuilder sn);

	    // DECLDIR int get_gpio_map(uint32_t dgi_hndl, uint8_t* gpio_map);
	
	    // DECLDIR int is_msd_mode(char* serial_number);
        [DllImport("dgilib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]        
        public static extern int is_msd_mode(StringBuilder sn);

	    // DECLDIR int set_mode(char* sn, int nmbed);
        [DllImport("dgilib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int set_mode(StringBuilder sn, int nmbed);
    }


    //
    //
    //
    static class Connection
    {
	    // Connection commands

	    // DECLDIR int connection_status(uint32_t dgi_hndl);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int connection_status(UInt32 handle);

	    // DECLDIR int connect(char* sn, uint32_t* dgi_hndl);
        [DllImport("dgilib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int connect(StringBuilder sn, out UInt32 handle);

        // DECLDIR int disconnect(uint32_t dgi_hndl);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int disconnect(UInt32 handle);

	    // DECLDIR int start_polling(uint32_t dgi_hndl);
	    // DECLDIR int stop_polling(uint32_t dgi_hndl);

        // DECLDIR int get_fw_version(uint32_t dgi_hndl, unsigned char* major, unsigned char* minor);
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_fw_version(UInt32 handle, out Byte major, out Byte minor);
    }


    //
    //
    //
    static class DeviceControl
    {
        // Device control

        // DECLDIR int target_reset(uint32_t dgi_hndl, bool hold_reset);
    }


    //
    //
    //
    static class VersionInformation
    {
	    // Version information 

        // DECLDIR int get_major_version();
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_major_version();

        // DECLDIR int get_minor_version();
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_minor_version();

        // DECLDIR int get_build_number();
        [DllImport("dgilib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_build_number(); 
    }


    //
    //
    // 
    static class Interface
    {
	    // Interface commands

	    // DECLDIR int interface_list(uint32_t dgi_hndl, unsigned char* interfaces, unsigned char* count);
	    // DECLDIR int interface_enable(uint32_t dgi_hndl, int interface_id, bool timestamp);
	    // DECLDIR int interface_disable(uint32_t dgi_hndl, int interface_id);
	    // DECLDIR int interface_set_configuration(uint32_t dgi_hndl, int interface_id, unsigned int* config_id, unsigned int* config_value, unsigned int config_cnt);
	    // DECLDIR int interface_get_configuration(uint32_t dgi_hndl, int interface_id, unsigned int* config_id, unsigned int* config_value, unsigned int* config_cnt);
	    // DECLDIR int interface_clear_buffer(uint32_t dgi_hndl, int interface_id);
	    // DECLDIR int interface_read_data(uint32_t dgi_hndl, int interface_id, unsigned char* buffer, unsigned long long* timestamp, int* length, unsigned int* ovf_index, unsigned int* ovf_length, unsigned int* ovf_entry_count);
	    // DECLDIR int interface_write_data(uint32_t dgi_hndl, int interface_id, unsigned char* buffer, int* length);
	    // DECLDIR int interface_get_health(uint32_t dgi_hndl, int interface_id, unsigned int* health);
    }


    //
    //
    //
    static class Auxiliary
    {
	    // Auxiliary commands

	    // DECLDIR int auxiliary_power_initialize(dgi_handle_t *handle, uint32_t dgi_hndl);
	    // DECLDIR int auxiliary_power_uninitialize(dgi_handle_t handle);

	    // DECLDIR int auxiliary_power_start(dgi_handle_t handle, int mode, int parameter);
	    // DECLDIR int auxiliary_power_stop(dgi_handle_t handle);

	    // DECLDIR int auxiliary_power_get_status(dgi_handle_t handle);

	    // DECLDIR int auxiliary_power_trigger_calibration(dgi_handle_t handle, int type);
	    // DECLDIR int auxiliary_power_get_circuit_type(dgi_handle_t handle, int* circuit);
	    // DECLDIR int auxiliary_power_get_calibration(dgi_handle_t handle, uint8_t data[], size_t length);
	    // DECLDIR bool auxiliary_power_calibration_is_valid(dgi_handle_t handle);

	    //DECLDIR int auxiliary_power_register_buffer_pointers(dgi_handle_t handle, float* buffer, double* timestamp, size_t* length, size_t max_length, int channel, int type);
	    //DECLDIR int auxiliary_power_unregister_buffer_pointers(dgi_handle_t handle, int channel, int type);
	    //DECLDIR int auxiliary_power_copy_data(dgi_handle_t handle, float* buffer, double* timestamp, size_t* length, size_t max_length, int channel, int type);
	    //DECLDIR int auxiliary_power_lock_data_for_reading(dgi_handle_t handle);
	    //DECLDIR int auxiliary_power_free_data(dgi_handle_t handle);
    }

    //
    //
    //
    private UInt32 deviceHandle = 0;

    //
    //
    //
    public sharpDGILib()
    {
    }


    //
    //
    //
    public void Discover()
    {
        Discovery.discover();
    }


    //
    //
    //
    public string selectedDevice;


    //
    //
    //
    public Int32 DeviceCount
    {
        get
        {
            return Discovery.get_device_count();
        }
    }
    
           

    //
    //
    //
    public string DeviceName
    {
        get
        {
            StringBuilder text = new StringBuilder();
            text.Capacity = 1024;

            if (Discovery.get_device_name(0, text) == 0)
            {
                return text.ToString();
            }
            return "";
        }
    }


    //
    //
    //
    public string Serial
    {
        get
        {
            StringBuilder text = new StringBuilder();
            text.Capacity = 1024;

            if (Discovery.get_device_serial(0, text) == 0)
            {
                return text.ToString();
            }
            return "";
        }
    }


    //
    //
    //
    public bool isDgiMode
    {
        get
        {
            return Discovery.is_msd_mode(new StringBuilder(selectedDevice)) == 0;
        }
    }


    //
    //
    //
    public void setDgiModeActive()
    {
        // 0 mbed mode
        // 1 DGI mode
        Discovery.set_mode(new StringBuilder(selectedDevice), 1);
    }


    //
    //
    //
    public bool Connect()
    {
        return Connection.connect(new StringBuilder(selectedDevice), out deviceHandle) == 0;
    }


    //
    //
    //
    public void Disconnect()
    {
        Connection.disconnect(deviceHandle);
        deviceHandle = 0;
    }


    //
    //
    //
    public string FirmwareVersion()
    {
        Byte major, minor;
        if (Connection.get_fw_version(deviceHandle, out major, out minor) == 0)
        {
            return String.Format("{0}.{1}", major, minor);
        }

        return "";
    }

}