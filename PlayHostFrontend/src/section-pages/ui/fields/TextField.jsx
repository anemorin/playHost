import { useField } from "formik";
import { useState } from "react";
import { observer } from "mobx-react";

const TextInput = ({
  label,
  type,
  disable = false,
  canEdit = true,
  ...props
}) => {
  const [field, meta] = useField(props);
  const [isDisabled, setIsDisabled] = useState(disable);

  return (
    <div
      hasError={meta.touched && !!meta.error}
      style={{ marginBottom: "10px", }}
    >
      <label htmlFor={props.id || props.name}>{label}</label>
      <input
        style={{backgroundColor: "rgba(70, 90, 126, 0.4) !important",}}
        {...field}
        {...props}
        disabled={isDisabled}
        type={type ??"text"}
        className="form-control"
      />
      {meta.touched && meta.error && (
        <div style={{ color: "red" }}>{meta.error}</div>
      )}
    </div>
  );
};

export default observer(TextInput);
