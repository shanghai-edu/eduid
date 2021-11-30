DROP FUNCTION IF EXISTS uuid_to_bin;
DROP FUNCTION IF EXISTS uuid_v5;
DROP FUNCTION IF EXISTS eduid;

DELIMITER //

CREATE FUNCTION uuid_to_bin(s CHAR(36))
  RETURNS BINARY(16)
  RETURN UNHEX(CONCAT(LEFT(s, 8), MID(s, 10, 4), MID(s, 15, 4), MID(s, 20, 4), RIGHT(s, 12))) //


CREATE FUNCTION `uuid_v5`(ns CHAR(36), name VARCHAR(2000))
    RETURNS CHAR(36)
  BEGIN
    SET @ns_bin = uuid_to_bin(ns);
    SET @prehash_value = CONCAT(@ns_bin, name);
    SET @hashed_value = SHA1(@prehash_value);

    SET @time_hi = MID(@hashed_value, 13, 4);
    SET @time_hi = CONV(@time_hi, 16, 10) & 0x0fff;
    SET @time_hi = @time_hi & ~(0xf000);
    SET @time_hi = @time_hi | (5 << 12);

    SET @clock_seq_hi = MID(@hashed_value, 17, 2);
    SET @clock_seq_hi = CONV(@clock_seq_hi, 16, 10);
    SET @clock_seq_hi = @clock_seq_hi & 0x3f;
    SET @clock_seq_hi = @clock_seq_hi & ~(0xc0);
    SET @clock_seq_hi = @clock_seq_hi | 0x80;

    SET @time_low = LEFT(@hashed_value, 8);
    SET @time_mid = MID(@hashed_value, 9, 4);
    SET @time_hi_and_version = lpad(conv(@time_hi, 10, 16), 4, '0');
    SET @clock_seq_hi_and_reserved = lpad(conv(@clock_seq_hi, 10, 16), 2, '0');
    SET @clock_seq_low = MID(@hashed_value, 19, 2);
    SET @node = lpad(MID(@hashed_value, 21, 12), 12, '0');

    SET @clock_seq = CONCAT(@clock_seq_hi_and_reserved, @clock_seq_low);

    SET @uuid_str = CONCAT_WS('-', @time_low, @time_mid, @time_hi_and_version, @clock_seq, @node);

    RETURN LOWER(@uuid_str);
  END //

CREATE FUNCTION eduid(name VARCHAR(2000))
  RETURNS CHAR(36)
  RETURN uuid_v5('b22e8988-6d15-5bff-b3a6-8e85a8a79f37',name) //

-- Switch back the delimiter
DELIMITER ;